    MemoryStream ms = new MemoryStream(); 
    System.Windows.Media.Imaging.BmpBitmapEncoder bbe = new BmpBitmapEncoder();
    bbe.Frames.Add(BitmapFrame.Create(new Uri(img.Source.ToString(),UriKind.RelativeOrAbsolute)));
    
    bbe.Save(ms); 
    System.Drawing.Image img2 = System.Drawing.Image.FromStream(ms); 
    button1.Image = img2;
