    string image = "/MyData/" + myObject.ImageName + "/big.png";
    BitmapImage bmp = new BitmapImage(new Uri(image , UriKind.Relative));
    if(bmp==null)
    {
    image = "/MyData/" + myObject.ImageName + "/small.png";
    bmp = new BitmapImage(new Uri(image , UriKind.Relative));
    }
    MyImage.Source = bmp;
