       private Bitmap OpenImageWithoutLockingIt(string imagePath)
        {
            if (System.IO.File.Exists(imagePath) == false)
                return null;
            using (Image imfTemp = Image.FromFile(imagePath))
            {
                Bitmap MemImage = new Bitmap(imfTemp.Width, imfTemp.Height);
                using (Graphics g = Graphics.FromImage(MemImage))
                {
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                    g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    g.Clear(Color.Transparent);
                    g.DrawImage(imfTemp, 0, 0, MemImage.Width, MemImage.Height);
                    return MemImage;
                }
            }
        }
        private bool DeleteImageFile(string filePath, bool DeleteAlsoReadonlyFile)
        {
            try
            {
                if (System.IO.File.Exists(filePath) == false)
                    return true;
                if (DeleteAlsoReadonlyFile)
                {
                    FileInfo fileInf = new FileInfo(filePath);
                    if (fileInf.IsReadOnly)
                    {
                        //remove readonly attribute, otherwise File.Delete throws access violation exception.
                        fileInf.IsReadOnly = false;
                    }
                }
                System.IO.File.Delete(filePath);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
