    MediaLibrary library = new MediaLibrary();
    Picture picture = library.Pictures[rnd.Next(0, library.Pictures.Count - 1)];
            
    BitmapImage bitmapimage = new BitmapImage();
    bitmapimage.SetSource(picture.GetImage());
    BackgroundImg.ImageSource = bitmapimage;
