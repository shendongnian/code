    System.IO.MemoryStream ms = New System.IO.MemoryStream();
    Bitmap signatureImage  = New Bitmap(800, 800);
    
    signatureImage  = SignObj.SigJsonToImage(signatureJson);
    signatureImage .Save(ms, Imaging.ImageFormat.Bmp);
    signatureImage .Save("FilePath/" + "image.png");
