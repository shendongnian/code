    var colTemp = new SolidColorBrush(Color.FromArgb(255, 174, 190, 206));
                var TestTile = new Grid()
                {                     
                    Background = colTemp,
                    Height = 336,
                    Width = 336,
                };                   
                var ico = new Image() {
                    Source = new BitmapImage(new Uri("Images/mCloudSunT.png", UriKind.Relative)),
                };
                TestTile.Children.Add(ico);
    ....
    bitmap.Render(TestTile, new TranslateTransform());
    bitmap.Invalidate();
