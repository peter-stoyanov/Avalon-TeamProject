﻿using Avalon.Models;
using Avalon.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Avalon.Client
{
    /// <summary>
    /// Interaction logic for SearchBeerWin.xaml
    /// </summary>
    public partial class SearchBeerWin : Window
    {
        public SearchBeerWin()
        {
            InitializeComponent();
            beersDatagrid.DataContext = BeerService.GetAllBeers();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            AddSaleWin.AddBeerToSaleList(this.beersDatagrid.SelectedItem as Beer);

            this.Close();
            
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string beerName = SearchTextBox.Text;

            if (beerName == null || beerName.Length == 0)
            {
                WarningLabel.Visibility = Visibility.Visible;
                WarningLabel.Content = "Beer name cannot be empty.";
                return;
            }

            //if (!isBeerExist)
            //{
            //    WarningLabel.Visibility = Visibility.Visible;
            //    WarningLabel.Content = "There aren't any beers with this name.";
            //    return;
            //}

            int beerCount = BeerService.BeerCount(beerName);

            beersDatagrid.DataContext = BeerService.GetBeersByName(beerName);

        }

    }
}
