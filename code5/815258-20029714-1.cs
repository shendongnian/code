      private void Viewport_Tap(object sender, System.Windows.Input.GestureEventArgs e)
      {
         int imageHeight = (Viewport.Source as BitmapImage).PixelHeight;
         int imageWidth = (Viewport.Source as BitmapImage).PixelWidth;
         Canvas myCanvas = new Canvas();
         Rectangle myBorder = new Rectangle();
         myBorder.Width = imageWidth;
         myBorder.Height = imageHeight;
         myBorder.Stroke = new SolidColorBrush(Colors.Red);
         myBorder.StrokeThickness = 10;
         Image toBorder = new Image();
         toBorder.Source = Viewport.Source as BitmapImage;
         myCanvas.Children.Add(toBorder);
         myCanvas.Children.Add(myBorder);
         WriteableBitmap newImage = new WriteableBitmap(myCanvas, null);
         //Viewport.Source = newImage; - you can use this but watch out that Viewport.Source now is not BitmapImage
         //Below is one method how to make it BitmapImage
         //You can of course save newImage to file or whatever you want
         //You can also unsubscribe this event to prevent it from second tap which will cause Exception at first line (BitmaImage != WriteableBitmap)
         MemoryStream memoryStream = new MemoryStream();
         newImage.SaveJpeg(memoryStream, imageWidth, imageHeight, 0, 100);
         BitmapImage newBitmap = new BitmapImage();
         newBitmap.SetSource(memoryStream);
         Viewport.Source = newBitmap;
      }
