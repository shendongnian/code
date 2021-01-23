    using(Bitmap MainImg = new System.Drawing.Bitmap(txtLoginImage.Text))            
    using(Bitmap NewImage = ConvertToGrayScale(MainImg))
    {
      NewImage.Save(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\Temp\\" + 
                               strFileName, System.Drawing.Imaging.ImageFormat.Bmp);
      NewImage.Dispose();
    }
