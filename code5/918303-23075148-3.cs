    internal static Image CreateImage(string fileName, int desiredPixelWidth)
    {
      Image myImage = new Image();
      //set image source
      myImage.Source = CreateSource(fileName);
      myImage.Width = desiredPixelWidth;
      return myImage;
    }
    internal static BitmapImage CreateSource(string fileName)
    {
      var file = new FileInfo(fileName);
      FormDrawing.Image im = FormDrawing.Image.FromFile(file.FullName);
      int actualPixelWidth = im.Width;
      Uri fileUri = new Uri(file.FullName);
      // Create source
      BitmapImage myBitmapImage = new BitmapImage();
      // BitmapImage.UriSource must be in a BeginInit/EndInit block
      myBitmapImage.BeginInit();
      myBitmapImage.UriSource = fileUri;
      // To save significant application memory, set the DecodePixelWidth or   
      // DecodePixelHeight of the BitmapImage value of the image source to the desired  
      // height or width of the rendered image. If you don't do this, the application will  
      // cache the image as though it were rendered as its normal size rather then just  
      // the size that is displayed. 
      // Note: In order to preserve aspect ratio, set DecodePixelWidth 
      // or DecodePixelHeight but not both.
      myBitmapImage.DecodePixelWidth = actualPixelWidth;
      myBitmapImage.EndInit();
      return myBitmapImage;
    }
