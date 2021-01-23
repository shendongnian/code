    private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (sender as Button);
            if (button != null)
            {
                var data = button.DataContext as ItemViewModel;
                if (data != null)
                {
                    //Save to isolated storage
                    IsolatedStorageManager.FeedItemViewModel = data;
                    //redirect to next Page.
                    this.NavigationService.Navigate(new Uri("/lineThreePage.xaml", UriKind.Relative));
                }
                else
                {
                    MessageBox.Show("An error occured, either the sender is not a button or the data context is not of type ItemViewModel");
                }
            }
            else
            {
                MessageBox.Show("An error occured, either the sender is not a button or the data context is not of type ItemViewModel");
            }
        }
