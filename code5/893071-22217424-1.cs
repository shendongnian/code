    string image = "/MyData/" + myObject.ImageName + "/big.png";
    string fileName = Path.GetFileName(image);
    if(!string.IsNullOrEmpty(fileName))
    {
     MessageBox.Show("File Exist -"+fileName);
     }
     else
     {
    MessageBox.Show("No File Exist -");
    }
    BitmapImage bmp = new BitmapImage(new Uri(image , UriKind.Relative));
    if(bmp==null)
     {
     image = "/MyData/" + myObject.ImageName + "/small.png";
    bmp = new BitmapImage(new Uri(image , UriKind.Relative));
    }
    MyImage.Source = bmp;
