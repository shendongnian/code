    Uri uri = new Uri("AbsoluteUriPath.png", UriKind.Absolute);
    BitmapImage img1 = new BitmapImage(uri);
    img1.CreateOptions = BitmapCreateOptions.None;
    img1.ImageOpened += (s, e) =>
    {
          WriteableBitmap bitmap = new WriteableBitmap(img1);
          var blurredBitmap = WriteableBitmapExtensions.Convolute(bitmap,
                    WriteableBitmapExtensions.KernelGaussianBlur5x5);
                ImageControl.Source = blurredBitmap;
    };
