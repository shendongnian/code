    class Program
    {
        static IList<Bitmap> SplitImage(Bitmap sourceBitmap, int splitHeight)
        {
            Size dimension = sourceBitmap.Size;
            Rectangle sourceRectangle = new Rectangle(0, 0, dimension.Width, splitHeight);
            Rectangle targetRectangle = new Rectangle(0, 0, dimension.Width, splitHeight);
            IList<Bitmap> results = new List<Bitmap>();
            while (sourceRectangle.Top < dimension.Height)
            {
                Bitmap pageBitmap = new Bitmap(targetRectangle.Size.Width, sourceRectangle.Bottom < dimension.Height ?
                    targetRectangle.Size.Height
                    :
                    dimension.Height - sourceRectangle.Top, PixelFormat.Format32bppArgb);
                using (Graphics g = Graphics.FromImage(pageBitmap))
                {
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
                    g.DrawImage(sourceBitmap, targetRectangle, sourceRectangle, GraphicsUnit.Pixel);
                }
                sourceRectangle.Y += sourceRectangle.Height;
                results.Add(pageBitmap);
            }
            return results;
        }
        static void Main(string[] args)
        {
            string sourceFilename = Environment.CurrentDirectory + @"\testimage.jpg";
            Bitmap sourceBitmap = (Bitmap)Image.FromFile(sourceFilename);
            var images = SplitImage(sourceBitmap, 79);
            int len = images.Count;
            for (int x = len; --x >= 0; )
            {
                var bmp = images[x];
                string filename = "Images-" + x + ".bmp";
                bmp.Save(Environment.CurrentDirectory + @"\" + filename, ImageFormat.Bmp);
                images.RemoveAt(x);
                bmp.Dispose();
                Console.WriteLine("Saved " + filename);
            }
            Console.WriteLine("Done with the resizing");
        }
    }
