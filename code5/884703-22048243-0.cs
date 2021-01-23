    protected void Page_Load(object sender, EventArgs e)
        {
            Response.Clear();
            Response.ContentType = "image/png";
            Bitmap bmp = new Bitmap(W, H, PixelFormat.Format24bppRgb);
            Graphics g = Graphics.FromImage(bmp);
            //lots of drawing code
            using (MemoryStream ms = new MemoryStream())
            {
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                Response.BinaryWrite(ms.ToArray());
            }
            bmp.Dispose();
            Response.End();
        }
