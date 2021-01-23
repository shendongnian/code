    public static void CropAndOverwrite(string imgPath, int x1, int y1, int height, int width)
        {
            //Create a rectanagle to represent the cropping area
            Rectangle rect = new Rectangle(x1, y1, width, height);
            //see if path if relative, if so set it to the full path
            if (imgPath.StartsWith("~"))
            {
                imgPath = Server.MapPath(imgPath);
            }
            //Load the original image
            Bitmap bMap = new Bitmap(imgPath);
            //The format of the target image which we will use as a parameter to the Save method
            var format = bMap.RawFormat;
            //Draw the cropped part to a new Bitmap
            var croppedImage = bMap.Clone(rect, bMap.PixelFormat);
            //Dispose the original image since we don't need it any more
            bMap.Dispose();
            //Remove the original image because the Save function will throw an exception and won't Overwrite by default
            if (System.IO.File.Exists(imgPath))
                System.IO.File.Delete(imgPath);
            //Save the result in the format of the original image
            croppedImage.Save(imgPath);
            //Dispose the result since we saved it
            croppedImage.Dispose();
        }
