        public static Byte[] ReturnByteArray(string inputString)
        {
            QRCode4CS.QRCode qrcode = new QRCode4CS.QRCode(new QRCode4CS.Options(inputString));
            qrcode.Make();
            Image canvas = new Bitmap(86, 86);
            Graphics artist = Graphics.FromImage(canvas);
            artist.Clear(Color.White);
            for (int row = 0; row < qrcode.GetModuleCount(); row++)
            {
                for (int col = 0; col < qrcode.GetModuleCount(); col++)
                {
                    bool isDark = qrcode.IsDark(row, col);
                    if (isDark == true)
                    {
                        artist.FillRectangle(Brushes.Black, 2 * row + 10, 2 * col + 10, 2 * row + 15, 2 * col + 15);
                    }
                    else
                    {
                        artist.FillRectangle(Brushes.White, 2 * row + 10, 2 * col + 10, 2 * row + 15, 2 * col + 15);
                    }
                }
            }
            artist.FillRectangle(Brushes.White, 0, 76, 86, 86);
            artist.FillRectangle(Brushes.White, 76, 0, 86, 86);
            artist.Dispose();
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            canvas.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            byte[] imagedata = null;
            imagedata = ms.GetBuffer();
            return imagedata;
        }
