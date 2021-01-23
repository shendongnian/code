        private void RentButton_Click(object sender, RoutedEventArgs e)
        {
            ItemsList.ItemContainerStyle = (System.Windows.Style)Resources["RentListViewItemStyle"];
            _MainWindowViewModel.RentButton_Click();
        }
        private void BuyButton_Click(object sender, RoutedEventArgs e)
        {
            ItemsList.ItemContainerStyle = (System.Windows.Style)Resources["BuyListViewItemStyle"];
            _MainWindowViewModel.BuyButton_Click();
        }
        private void PropertyButton_Click(object sender, RoutedEventArgs e)
        {
            ItemsList.ItemContainerStyle = (System.Windows.Style)Resources["OverviewListViewItemStyle"];
            _MainWindowViewModel.PropertyButton_Click();
        }
