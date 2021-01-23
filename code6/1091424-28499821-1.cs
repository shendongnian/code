    private void Go_Click(object sender, RoutedEventArgs e)
        {
            if (LoadedImage.Source != null)
            {
                var imagePosition = loaded.TransformToAncestor(LoadedImage).Transform(new Point(0, 0));
                Rect rect1 = new Rect(Math.Max(Canvas.GetLeft(selectionRectangle) - imagePosition.X, 0), Canvas.GetTop(selectionRectangle), selectionRectangle.Width, selectionRectangle.Height);
                Int32Rect rcFrom = new Int32Rect();
                rcFrom.X = (int)((rect1.X) * (LoadedImage.Source.Width) / (LoadedImage.ActualWidth));
                rcFrom.Y = (int)((rect1.Y) * (LoadedImage.Source.Height) / (LoadedImage.ActualHeight));
                rcFrom.Width = (int)((rect1.Width) * (LoadedImage.Source.Width) / (LoadedImage.ActualWidth));
                rcFrom.Height = (int)((rect1.Height) * (LoadedImage.Source.Height) / (LoadedImage.ActualHeight));
                BitmapSource bs = new CroppedBitmap(LoadedImage.Source as BitmapSource, rcFrom);
                PreviewImage.Source = bs;
            }
        }
