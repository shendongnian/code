    public static Image ResizeImage(Image img, int width, int height, bool preserveAspectRatio = false)
        {
            
            int newWidth;
            int newHeight;
            if (preserveAspectRatio)
            {
                int originalWidth = img.Width;
                int originalHeight = img.Height;
                float percentWidth = (float)width / (float)originalWidth;
                float percentHeight = (float)height / (float)originalHeight;
                float percent = percentHeight < percentWidth ? percentHeight : percentWidth;
                //Rounding to get the set width to the exact pixel
                newWidth = (float)originalWidth * percent < (float)width ? (int)(Math.Ceiling((float)originalWidth * percent)) : (int)((float)originalWidth * percent);
                //Rounding to get the set height to the exact pixel
                newHeight = (float)originalHeight * percent < (float)height ? (int)(Math.Ceiling((float)originalHeight * percent)) : (int)((float)originalHeight * percent);
            }
            else
            {
                newWidth = width;
                newHeight = height;
            }
            // Create a new bitmap with the size 
            Bitmap TempBitmap = new Bitmap(newWidth, newHeight);
            // Create a new image that contains are quality information
            Graphics NewImage = Graphics.FromImage(TempBitmap);
            NewImage.CompositingQuality = CompositingQuality.HighQuality;
            NewImage.SmoothingMode = SmoothingMode.HighQuality;
            NewImage.InterpolationMode = InterpolationMode.HighQualityBicubic;
            
            // Create a rectangle and draw the image
            Rectangle imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
            NewImage.DrawImage(img, imageRectangle);
            return TempBitmap;
    
        }
