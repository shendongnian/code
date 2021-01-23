        /// <summary>
        /// Saves the image to  specified stream and format.
        /// </summary>
        /// <param name="image">The image to save.</param>
        /// <param name="outputStream">The stream to used.</param>
        /// <param name="format">The format of new image.</param>
        /// <param name="quality">The quality of the image in percent.</param>
        public static void SaveTo(this Image image, Stream outputStream, ImageFormat format, int quality)
        {
            EncoderParameters encoderParameters = new EncoderParameters(1);
            encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, quality);
            ImageCodecInfo[] encoders = ImageCodecInfo.GetImageEncoders();
            if (format == ImageFormat.Gif)
            {
                image.Save(outputStream, ImageFormat.Gif);
            }
            else if (format == ImageFormat.Jpeg)
            {
                image.Save(outputStream, encoders[1], encoderParameters);
            }
            else if (format == ImageFormat.Png)
            {
                image.Save(outputStream, encoders[4], encoderParameters);
            }
            else if (format == ImageFormat.Bmp)
            {
                image.Save(outputStream, encoders[0], encoderParameters);
            }
            else
            {
                image.Save(outputStream, format);
            }
        }
