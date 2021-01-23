            Form draw = new Drawing();      // Opens the drawing form
            draw.Show();
            try
            {
                var path = this.outputFolder.Text; // Path where images will be saved to
                if (!Directory.Exists(path))
                {
                    DirectoryInfo di = Directory.CreateDirectory(path);     // Create a directory if it does not already exist
                }
                Bitmap bitmap = new Bitmap(Convert.ToInt32(1024), Convert.ToInt32(1024), System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                Graphics g = Graphics.FromImage(bitmap);
                System.Drawing.Pen myPen;
                myPen = new System.Drawing.Pen(System.Drawing.Color.Red);
                g.DrawLine(myPen, 0, 0, 1024, 1024);
                bitmap.Save(path + "\\" + i + ".png", ImageFormat.Png);
            }
            catch { }
