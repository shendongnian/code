        /// <summary>
        /// Compress the image
        /// </summary>
        /// <param name="stream">Image stream</param>
        /// <param name="format">Image format</param>
        /// <returns>Byte array representing the image</returns>
        public static byte[] GetCompressedImage(Image original, ImageFormat format)
        {
            ImageCodecInfo imgCodec = ImageCodecInfo.GetImageEncoders().First(c => c.FormatID == format.Guid);
            EncoderParameters codecParams = new EncoderParameters(1);
            codecParams.Param[0] = new EncoderParameter(Encoder.Quality, 70L);
            using (var bitmap = new Bitmap(original))
            {
                using (var ms = new MemoryStream())
                {
                    bitmap.Save(ms, imgCodec, codecParams);
                    return ms.ToArray();
                }
            }
        }
