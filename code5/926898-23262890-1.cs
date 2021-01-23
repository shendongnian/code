         var canvas = new Canvas();
            canvas.Width = 336;
            canvas.Height = 336;
            canvas.Background = new SolidColorBrush(Colors.Red);
            var textBlock = new TextBlock();
            textBlock.Text = "sample";
            textBlock.Margin = new Thickness(130, 250, 0, 0);
            textBlock.Width = 336;
            textBlock.Foreground = new SolidColorBrush(Colors.Blue); 
            textBlock.FontSize = 26;
            canvas.Children.Add(textBlock);
           
            Image img = new Image();
            img.Source = new BitmapImage(new Uri("Images/TileBgs/Medium/sun.png", UriKind.Relative));
            img.Margin = new Thickness(40, 10, 0, 0);
            img.Width = 250;
            canvas.Children.Add(img);
            Maingrid.Children.Add(canvas);
