        private void zoomPicBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int x = zoomPicBox1.ImgDoubleClick.X;
            int y = zoomPicBox1.ImgDoubleClick.Y;
            using (Graphics grD = Graphics.FromImage(_bmp))
            //using (Graphics grD = Graphics.FromImage(zoomPicBox1.Image))
            {
                grD.PageUnit = GraphicsUnit.Pixel;
                grD.DrawEllipse(Pens.Black, x - 4, y - 4, 8, 8);
                grD.DrawEllipse(Pens.Black, x - 3, y - 3, 6, 6);
                grD.DrawEllipse(Pens.Black, x - 2, y - 2, 4, 4);
                grD.DrawEllipse(Pens.Black, x - 1, y - 1, 2, 2);
            }
            this.zoomPicBox1.Invalidate();
        }
