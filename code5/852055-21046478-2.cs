    private void WriteStringOnImage()
        {
            try
            {
                byte[] imgData = getData(@"E:\0000.tif");
                using (System.Drawing.Image img = System.Drawing.Image.FromStream(new MemoryStream(imgData)))
                {
                    for (int i = 1; i <= 1000; i++)
                    {
                        Bitmap img1 = new Bitmap(new Bitmap(img));
                        RectangleF rectf = new RectangleF(800, 550, 200, 200);
                        Graphics g = Graphics.FromImage(img1);
                        g.DrawString(i.ToString("0000"), new Font("Thaoma", 30), Brushes.Black, rectf);
                        img1.Save(@"E:\Img\" + i.ToString("0000") + ".tif");
                        g.Flush();
                        g.Dispose();
                        img1.Dispose();
                        GC.Collect();
                    }
                }
            }
            catch (Exception){}
        }
