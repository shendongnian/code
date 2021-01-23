        public static string ToBase64String(this System.Drawing.Image imageIn)
        {
            if (imageIn == null)
                return null;
            ImageConverter converter = new ImageConverter();
            return Convert.ToBase64String((byte[])converter.ConvertTo(imageIn, typeof(byte[])));
        }
        public static Image FromBase64String(string imageString)
        {
            if (string.IsNullOrEmpty(imageString))
                return null;
            ImageConverter converter = new ImageConverter();
            return (Image)converter.ConvertFrom(Convert.FromBase64String(imageString));
        }
