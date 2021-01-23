    private void button1_Click(object sender, EventArgs e)
    {
       Bitmap bmp = new Bitmap(panel1.ClientSize.Width, panel1.ClientSize.Height);
       using (Graphics G = Graphics.FromImage(bmp))
           panel1.DrawToBitmap(bmp, panel1.ClientRectangle);
       // now we can save it..
       bmp.Save("d:\\foursome.jpg", ImageFormat.Jpeg);
       // and let it go:
       bmp.Dispose();
    }
