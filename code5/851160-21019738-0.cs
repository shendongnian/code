    private void btnSave_Click(object sender, EventArgs e)
    {
        Bitmap bmp = new Bitmap(pnlDraw.Width, pnlDraw.Height);
    
        pnlDraw.DrawToBitmap(bmp, new Rectangle(0, 0, pnlDraw.Width, pnlDraw.Height));
    
        bmp.Save(txtModelName.Text, System.Drawing.Imaging.ImageFormat.Jpeg);
    }
