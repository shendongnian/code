            byte[] bytearray = null;
            using (var ms = new MemoryStream())
            {
                if (imgPhoto.Source != null)
                {
                    var wbitmp = new WriteableBitmap((BitmapImage) imgPhoto.Source);
                    wbitmp.SaveJpeg(ms, 46, 38, 0, 100);
                    bytearray = ms.ToArray();
                }
            }
            if (bytearray != null)
            {
                Sighting.Instance.ImageData = Convert.ToBase64String(bytearray);
                PhotoModel.Instance.BitmapImage = bitmapImage;
            }
