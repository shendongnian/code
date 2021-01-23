     if (Clipboard.ContainsImage())
     {
         Image image = Clipboard.GetImage();
         image.Save(@"c:\temp\image.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
     }
