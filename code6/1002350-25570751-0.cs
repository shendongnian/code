        public static Image GetImageFromDB(byte[] tab)
        {
             if (tab == null) return null;
            try
            {
                MemoryStream ms = new MemoryStream(tab);
                if (ms != null)
                {
                    Image im = Image.FromStream(ms, true);
                    // or: Image.FromFile(imagepath);
                    im.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    ms.Dispose();
                    im.Save(savedImagePath));
                    return im;
                }
            }
            catch (Exception)
            {
            }
            return null;
        }
