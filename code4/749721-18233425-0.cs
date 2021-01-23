     public ActionResult DynamicImage()
        {
            using (Bitmap image = new Bitmap(200, 200))
            {
                using (Graphics g = Graphics.FromImage(image))
                {
                    string text = "Hello World!";
                    Font drawFont = new Font("Arial", 10);
                    SolidBrush drawBrush = new SolidBrush(Color.Black);
                    PointF stringPonit = new PointF(0, 0);
                    g.DrawString(text, drawFont, drawBrush, stringPonit);
                }
                MemoryStream ms = new MemoryStream();
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return File(ms.ToArray(), "image/png");
            }
        }
