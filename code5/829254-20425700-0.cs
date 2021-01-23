        private void Records_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab)
            {
                Records.SelectedItem = 
                     Records.ItemsSource
                         .First(item => 
                             item.Name.Contains(textBoxValue) || 
                             item.Artist.Contains(textBoxValue));
            }
        }
