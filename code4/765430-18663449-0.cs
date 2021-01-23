    Image.GetThumbnailImageAbort myCallback =
        new Image.GetThumbnailImageAbort(ThumbnailCallback);
    OpenFileDialog open = new OpenFileDialog();
    // image filters
    open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
    if (open.ShowDialog() == DialogResult.OK)
    {
        // display image in picture box
        upload = new Bitmap(open.FileName);
        pictureBox1.Image.GetThumbnailImage(114, 108, myCallback, IntPtr.Zero);
        this.CreateGraphics().DrawImage(upload, 150, 75);
    }
