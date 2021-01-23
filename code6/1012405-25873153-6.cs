    public static class BitmapHelper
    {
        public static void SaveToPng(this BitmapSource bitmap, string fileName)
        {
            var encoder = new PngBitmapEncoder();
            SaveUsingEncoder(bitmap, fileName, encoder);
        }
        public static void SaveUsingEncoder(this BitmapSource bitmap, string fileName, BitmapEncoder encoder)
        {
            BitmapFrame frame = BitmapFrame.Create(bitmap);
            encoder.Frames.Add(frame);
            using (var stream = File.Create(fileName))
            {
                encoder.Save(stream);
            }
        }
        public static void ImageLoadResizeAndSave(string inFile, string outFile, int newPixelHeight)
        {
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(inFile);
            image.EndInit();
            var newImage = BitmapHelper.ResizeImageToHeight(image, newPixelHeight);
            BitmapHelper.SaveToPng(newImage, outFile);
        }
        /// <summary>
        /// Resize the image to have the selected height, keeping the width proportionate.
        /// </summary>
        /// <param name="imgToResize"></param>
        /// <param name="newHeight"></param>
        /// <returns></returns>
        public static BitmapSource ResizeImageToHeight(BitmapSource imgToResize, int newPixelHeight)
        {
            double sourceWidth = imgToResize.PixelWidth;
            double sourceHeight = imgToResize.PixelHeight;
            var nPercentH = ((double)newPixelHeight / sourceHeight);
            double destWidth = Math.Max((int)Math.Round(sourceWidth * nPercentH), 1); // Just in case;
            double destHeight = newPixelHeight;
            var bitmap = new TransformedBitmap(imgToResize, new ScaleTransform(destWidth / imgToResize.PixelWidth, destHeight / imgToResize.PixelHeight));
            return bitmap;
        }
    }
