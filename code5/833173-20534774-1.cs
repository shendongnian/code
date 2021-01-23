    Button tba = new Button();
    Image myImage = new Image();
    BitmapImage bitmap = new BitmapImage();
    bitmap.BeginInit();
    bitmap.UriSource = new Uri(@"files.png" + lstQuestion[i].ImageURL.Substring(1), UriKind.Absolute);
    bitmap.EndInit();
    myImage.Source = myBitmapImage;
    myImage.Stretch = Stretch.None;
    tba.Content = myImage;
