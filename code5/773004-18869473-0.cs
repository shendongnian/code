    using (System.Drawing.Image imageFile = System.Drawing.Image.FromFile("temp.tif"))
    {
        System.Drawing.Imaging.FrameDimension frameDimensions = new System.Drawing.Imaging.FrameDimension(imageFile.FrameDimensionsList[0]);
        imageFile.SelectActiveFrame(frameDimensions, indexPage);
        using (System.Drawing.Bitmap newImage = new System.Drawing.Bitmap(imageFile.Size.Width, imageFile.Size.Height))
        {
            using (System.Drawing.Graphics gr = System.Drawing.Graphics.FromImage(newImage))
            {
                gr.Clear(System.Drawing.Color.White);
                gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                gr.DrawImage(imageFile, new System.Drawing.Rectangle(new System.Drawing.Point(0, 0), imageFile.Size));
            }
            //do whatever with the newImage bitmap
        }
    }
