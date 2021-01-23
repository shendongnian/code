      private async void testCartoon_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
       //the panel I want as an Image
       var rootElement = ContentPanel as FrameworkElement; 
       WriteableBitmap myWB = new WriteableBitmap((int)rootElement.ActualWidth,    (int)rootElement.ActualHeight);
       myWB.Render(rootElement, new MatrixTransform());
       myWB.Invalidate();
        using (var stream = new MemoryStream())
        {
          myWB.SaveJpeg(stream, myWB.PixelWidth, myWB.PixelHeight, 0, 100);
          stream.Seek(0, SeekOrigin.Begin);
          var backgroundSource = new StreamImageSource(stream);
          var filterEffect = new FilterEffect(backgroundSource);
          CartoonFilter cartoonFilter = new CartoonFilter();
          filterEffect.Filters = new[] { cartoonFilter };
          var renderer = new WriteableBitmapRenderer(filterEffect, _cartoonImageBitmap);
          _cartoonImageBitmap = await renderer.RenderAsync();
          ImageCartoon.Source = _cartoonImageBitmap;
        }
    }
