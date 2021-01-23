    private void bSave_Click(object sender, RoutedEventArgs e)
    {
        string fileLocation = System.IO.Path.GetDirectoryName(FileNmae);// get the selected file location
        string getFileName = System.IO.Path.GetFileName(FileNmae); //get the seleceted filename
        DateTime time = DateTime.Now;              // Use current time
        string format = "MMMddddHHmmssyyyy";
        string s2 = time.ToString(format) + getFileName; // add $ at front along with the folde name
    
    
        string filenamecombined = System.IO.Path.Combine(fileLocation, s2);//combine path. 
    
        #region Change the SpecialPhoto to be the size of its image and adjust the other images to match
        double w = SpecialPhoto.Width;
        double h = SpecialPhoto.Height;
        SpecialPhoto.Width = SpecialPhoto.Source.Width;
        SpecialPhoto.Height = SpecialPhoto.Source.Height;
        // Get the ratio of the change in width/height
        double rw = SpecialPhoto.Width / w;
        double rh = SpecialPhoto.Height / h;
        // Adjust the logos added to keep in the same relative position and size
        foreach (Image img in canvas.Children)
        {
            if (img == SpecialPhoto)
                continue;
            double left = Canvas.GetLeft(img);
            double top = Canvas.GetTop(img);
            Canvas.SetLeft(img, left * rw);
            Canvas.SetTop(img, top * rh);
            img.RenderTransform = new ScaleTransform(rw, rh);
        }
        #endregion
    
        RenderTargetBitmap renderTarget = new RenderTargetBitmap(
            (int)SpecialPhoto.Width,
            (int)SpecialPhoto.Height,
            96, 96, PixelFormats.Pbgra32);
    
        //renderTarget.Render(ViewedPhoto);
        ModifyPosition(canvas as FrameworkElement);
        renderTarget.Render(canvas);
        ModifyPositionBack(canvas as FrameworkElement);
    
        #region Undo the changes we did to the SpecialPhoto/logos
        SpecialPhoto.Width = w;
        SpecialPhoto.Height = h;
        foreach (Image img in canvas.Children)
        {
            if (img == SpecialPhoto)
                continue;
            double left = Canvas.GetLeft(img);
            double top = Canvas.GetTop(img);
            Canvas.SetLeft(img, left / rw);
            Canvas.SetTop(img, top / rh);
            img.RenderTransform = new ScaleTransform(1, 1);
        }
        #endregion
    
        JpegBitmapEncoder encoder = new JpegBitmapEncoder();
        encoder.Frames.Add(BitmapFrame.Create(renderTarget));
    
        //string imagePath = System.IO.Path.GetTempFileName();
        using (FileStream stream = new FileStream(filenamecombined, FileMode.Create))
        {
            encoder.Save(stream);
            stream.Dispose();
        }
    }
