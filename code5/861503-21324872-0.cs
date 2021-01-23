        // location is a textbox
        private void location_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (location.Text == "")
            { 
                ImageBrush watermark = new ImageBrush();
                watermark.ImageSource = 
                    new BitmapImage(new Uri(@"/Assets/Misc/watermark.png", UriKind.Relative));
                watermark.AlignmentX = AlignmentX.Left;
                watermark.Stretch = Stretch.None;
                watermark.Opacity = .75;
                location.Background = watermark;
            }
            else
            {
                location.Background = new SolidColorBrush(Colors.White);
            }
        }
        private void location_LostFocus(object sender, RoutedEventArgs e)
        {
            location.Background.Opacity = .75;
        }
