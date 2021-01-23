    private void btnSave_Click(object sender, EventArgs e)
    {
        saveDialog.FileName = txtModelName.Text;
    
        if (saveDialog.ShowDialog() == DialogResult.OK)
        {
            Bitmap bmp = new Bitmap(pnlDraw.Width, pnlDraw.Height);
    
            pnlDraw.DrawToBitmap(bmp, new Rectangle(0, 0,
                pnlDraw.Width, pnlDraw.Height));
    
            var fileName = saveDialog.FileName;
            if(!System.IO.Path.HasExtension(fileName) || System.IO.Path.GetExtension(fileName) != "jpg")
                fileName = fileName + ".jpg";
    
            bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
    }
