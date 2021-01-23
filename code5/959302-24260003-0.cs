    private void InBitmapZeichnen()
    {
        Graphics g1 = Graphics.FromImage(bmp12);
        g1.PageUnit = GraphicsUnit.Pixel;
        g1.SmoothingMode = SmoothingMode.AntiAlias;
        //g1.InterpolationMode = InterpolationMode.HighQualityBilinear;
        Font f = new Font("Verdana", 8f);
        Font f1 = new Font("Verdana", 8f);
        Font f2 = new Font("Verdana", 10, System.Drawing.FontStyle.Bold);
        Brush b = new SolidBrush(Color.YellowGreen);
        Brush b1 = new SolidBrush(Color.YellowGreen);
        Pen PenRaster = new Pen(Color.Black, 0.1f);
        if (mnuRaster.Checked == true)
        {
            float j = Rohrdurchmesser / (float)(trk.Value + 2);
            //g1.SmoothingMode = SmoothingMode.HighSpeed;
            for (int i = pic1.Width / (trk.Value + 2); i <= pic1.Width - pic1.Width / (trk.Value + 2); i += pic1.Width / (trk.Value + 2))
            {
                PointF PRaster1 = new PointF(i, 0);
                PointF PRaster2 = new PointF(i, pic1.Bottom);
                PointF PRaster3 = new PointF(0, i + 4);
                PointF PRaster4 = new PointF(pic1.Right, i + 4);
                using (var path = new GraphicsPath())
                {
                    path.AddString((j).ToString("0") + " mm", f.FontFamily, (int)f.Style, f.Size, new Point(i + 5, 5), null);
                    path.AddString((j).ToString("0") + " mm", f.FontFamily, (int)f.Style, f.Size, new Point(5, i + 5), null);
                    g1.FillPath(b, path);
                }
                //g1.DrawString((j).ToString("0") + " mm", f, b, new PointF(i + 5, 5));
                //g1.DrawString((j).ToString("0") + " mm", f, b, new PointF(5, i + 5));
                g1.DrawLine(PenRaster, PRaster1, PRaster2);
                g1.DrawLine(PenRaster, PRaster3, PRaster4);
                j += Rohrdurchmesser / (float)(trk.Value + 2);
            }
        }
    }
