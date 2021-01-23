                // Copy the selected part of the image.
                float zoomX = (float)original.Size.Width / pictureBox1.Width;
                float zoomY = (float)original.Size.Height / pictureBox1.Height;
                int wid = (int)(zoomX * Math.Abs(x0 - x1));
                int hgt = (int)(zoomY * Math.Abs(y0 - y1));
                if ((wid < 1) || (hgt < 1)) return;
                Bitmap area = new Bitmap(wid, hgt);
                using (Graphics gr = Graphics.FromImage(area))
                {
                    Rectangle source_rectangle =
                        new Rectangle((int)(zoomX * Math.Min(x0, x1)), (int)(zoomY * Math.Min(y0, y1)),
                            wid, hgt);
                    Rectangle dest_rectangle =
                        new Rectangle(0, 0, wid, hgt);
                    gr.DrawImage(original, dest_rectangle,
                        source_rectangle, GraphicsUnit.Pixel);
                }
