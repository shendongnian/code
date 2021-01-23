        public static byte[] ReadRotateAndWriteBitmap(byte[] imageBytes)
        {
            ImageConverter converter = new ImageConverter();
            using (Image img = (Image)converter.ConvertFrom(imageBytes))
            {
                if (img == null)
                    return null;
                img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                return (byte[])converter.ConvertTo(img, typeof(byte[]));
            }
        }
