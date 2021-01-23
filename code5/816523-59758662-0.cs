    public void DrawHistogram(int[] histogram)
        {
            var histogramHeight = 256;
            var bitmap = new Bitmap(1024, histogramHeight);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                for (int i = 0; i < histogram.Length; i++)
                {
                    float unit = (float)histogram[i] / histogram.Max();
                    graphics.DrawLine(Pens.Black,
                        new Point(i * 4, histogramHeight - 5),
                        new Point(i * 4, histogramHeight - 5 - (int)(unit * histogramHeight)));
                }
            }
            bitmap.Save(filename: @"C:\test\result.jpg");
        }
