            public void DrawDinoNames()
        {
            System.Drawing.Bitmap bmp;
            bmp = BitmapFromWriteableBitmap(writeableBitmap);
            Graphics g = Graphics.FromImage(bmp);
            for (int i = 0; i < Dinosaurs.Count; i++)
            {
                g.DrawString(Dinosaurs[i].PersonalName, new Font("Tahoma", 14), System.Drawing.Brushes.White, new PointF((float)Dinosaurs[i].Head.X, (float)Dinosaurs[i].Head.Y));
               
            }
            this.image.Source = BitmapToImageSource(bmp, System.Drawing.Imaging.ImageFormat.Bmp);
        }
