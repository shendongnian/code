    public static void CropAndOverwrite(string imgPath,int x1, int y1, int height, int width)
            {
                //Load the target image from file
                var img = Image.FromFile(imgPath);
    
                //The format of the target image which we will use as a parameter to the Save method
                var format = img.RawFormat;
               
                //Create a rectanagle to represent the cropping area
                Rectangle rect = new Rectangle(x1, y1, width, height);
               
                Bitmap bMap = new Bitmap(img);
                //Draw the cropped part to a new Bitmap
                var croppedImage = bMap.Clone(rect, bMap.PixelFormat);
    
                //Dispose the original image since we don't need it any more
                img.Dispose();
    
                //Remove the original image because the Save function will throw an exception and won't override
                if (System.IO.File.Exists(imgPath))
                    System.IO.File.Delete(imgPath);
    
                //Save the result in the format of the original image
                croppedImage.Save(imgPath, format);
                //Dispose the result since we saved it
                croppedImage.Dispose();
            }
