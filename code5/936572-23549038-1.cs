        public static System.Drawing.Bitmap GetPdfChart(int percentage)
        {
            if (percentage == 0) return null;
            int WIDTH = 130;
            int HEIGHT = 10;
            Bitmap bitmap = new Bitmap(WIDTH, HEIGHT);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, WIDTH, HEIGHT), Color.LightGreen, Color.Red, LinearGradientMode.Horizontal))
                {
                    graphics.FillRectangle(brush, new Rectangle(0, 0, WIDTH, HEIGHT));
                    using (Bitmap target = new Bitmap(WIDTH * percentage / 100, HEIGHT))
                    {
                        Rectangle cropped = new Rectangle(0, 0, WIDTH, HEIGHT);
                        using (Graphics graphicsTarget = Graphics.FromImage(target))
                        {
                            graphicsTarget .DrawImage(bitmap, new Rectangle(0, 0, cropped.Width, cropped.Height), cropped, GraphicsUnit.Pixel);
                            return bitmap; // IT IS RETURNED HERE, SO DO NOT DISPOSE
                            // should'nt this be target anyway?
                        }
                    }
                }
            }   
        }
