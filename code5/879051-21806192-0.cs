        private async void DeleteItem_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog md = new MessageDialog("Error");
            String result = DbDeletation();
            if (result != "OK")
                await md.ShowAsync();
        }
