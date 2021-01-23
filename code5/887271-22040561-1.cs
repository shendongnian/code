        private void button_click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (buttonPaura == button)
            {
                imagePaura.Visibility = System.Windows.Visibility.Visible;
            }
        }
