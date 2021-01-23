        // This method creates your controls and returns a listBoxItem with the specified content.
        private ListBoxItem createObject(String imgSource, String text)
        {
            var newImage = new Image() 
                { 
                    Source = new BitmapImage(new Uri(imgSource, UriKind.RelativeOrAbsolute)), 
                    Width = 72, 
                    Margin = new Thickness(0, 0, 5, 0) 
                };
            var newTextBox = new TextBox() 
                { 
                    IsReadOnly = true, 
                    Background = Brushes.Transparent, 
                    Foreground = Brushes.White, 
                    Width = 912, 
                    Text = text 
                };
            var newStackPanel = new StackPanel() { Orientation = Orientation.Horizontal };
            newStackPanel.Children.Add(newImage);
            newStackPanel.Children.Add(newTextBox);
            return new ListBoxItem() { Content = newStackPanel };
        }
        private void btnDoMagic(object sender, RoutedEventArgs e)
        {
            // Get your URI and textbox text here, and use them as arguments below.
            1stMagic.Items.Add(createObject("Sample URI", "Sample Textbox Content"));
        }
