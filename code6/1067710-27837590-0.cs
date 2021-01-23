    // stworzenie obrazu i przeskalowanie
        public Bitmap GetBitmap(double scalingFactor)
        {
            Bitmap image = new Bitmap(_width, _height, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
            // konwersja palety idexed na skale szarosci
            ColorPalette grayPalette = image.Palette;
            Color[] entries = grayPalette.Entries;
            for (int i = 0; i < 256; i++)
            {
                Color grayC = new Color();
                grayC = Color.FromArgb((byte)i, (byte)i, (byte)i);
                entries[i] = grayC;
            }
            image.Palette = grayPalette;
            // wrzut binary data do bitmapy
            BitmapData dataR = image.LockBits(new Rectangle(Point.Empty, image.Size), ImageLockMode.WriteOnly, image.PixelFormat);
            Marshal.Copy(_rawDataPresented, 0, dataR.Scan0, _rawDataPresented.Length);
            image.UnlockBits(dataR);
            // skalowanie wielkosci
            Size newSize = new Size((int)(image.Width * scalingFactor), (int)(image.Height * scalingFactor));
            Bitmap scaledImage = new Bitmap(image, newSize);
            return scaledImage;
        }
