        public static BitmapImage GetImage(Contact con)
        {
            if (con == null || con.Thumbnail == null)
            {
                return null;
            }
            var bitmapImage = new BitmapImage();
            bitmapImage.DecodePixelHeight = 256;
            bitmapImage.DecodePixelWidth = 256;
            Action load = async () =>
            {
                using (IRandomAccessStream fileStream = await con.Thumbnail.OpenReadAsync())
                {
                    await bitmapImage.SetSourceAsync(fileStream);
                }
            };
            load();
            return bitmapImage;
        }
