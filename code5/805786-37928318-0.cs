     private void txtBoxBA_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            // only allow 0-9 and "."
            e.Handled = !((e.Key.GetHashCode() >= 48 && e.Key.GetHashCode() <= 57));
                        
            // check if "." is already there in box.
            if (e.Key.GetHashCode() == 190)
                e.Handled = (sender as TextBox).Text.Contains(".");
        }
