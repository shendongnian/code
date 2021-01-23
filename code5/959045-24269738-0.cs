        private void MapPage_Click(object sender, RoutedEventArgs e)
        {
            if (this.Frame != null)
            {
                typeof(Views.MapPage).FromTbx = this.FromTxtBox.Text;
                typeof(Views.MapPage).ToTbx = this.ToTxtBox.Text; 
                this.Frame.Navigate(typeof(Views.MapPage));
            }
        }
