    using System.IO;
    using System.Windows.Media.Imaging;
    ...
    myImage = new BitmapImage(new Uri("http://i.stack.imgur.com/830Ke.jpg?s=128&g=1", UriKind.Absolute));
    myImage.CreateOptions = BitmapCreateOptions.None;
    myImage.ImageOpened += myImage_ImageOpened;
    ...
    void myImage_ImageOpened(object sender, RoutedEventArgs e)
    {
        MemoryStream ms = new MemoryStream();
        WriteableBitmap wb = new WriteableBitmap(myImage);
        wb.SaveJpeg(ms, myImage.PixelWidth, myImage.PixelHeight, 0, 100);
        byte[] imageBytes = ms.ToArray();
    }
