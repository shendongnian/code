            private void Test()
            {
                Bitmap bmp = new Bitmap(@"C:\Users\Public\Pictures\Sample Pictures\Desert.jpg");
                int[] histogram_r = new int[256];
                float max = 0;
    
                for (int i = 0; i < bmp.Width; i++)
                {
                    for (int j = 0; j < bmp.Height; j++)
                    {
                        int redValue = bmp.GetPixel(i, j).R;
                        histogram_r[redValue]++;
                        if (max < histogram_r[redValue])
                            max = histogram_r[redValue];
                    }
                }
    
                int histHeight = 128;
                Bitmap img = new Bitmap(256, histHeight + 10);
                using (Graphics g = Graphics.FromImage(img))
                {
                    for (int i = 0; i < histogram_r.Length; i++)
                    {
                        float pct = histogram_r[i] / max;   // What percentage of the max is this value?
                        g.DrawLine(Pens.Black,
                            new Point(i, img.Height - 5),
                            new Point(i, img.Height - 5 - (int)(pct * histHeight))  // Use that percentage of the height
                            );
                    }
                }
                img.Save(@"c:\temp\test.jpg");
            }
         }
     }
