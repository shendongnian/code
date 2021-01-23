    void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs)
    {
        if (pictureBox1.Image != null) { pictureBox1.Image.Dispose(); }
        Bitmap tempBitmap = (Bitmap)eventArgs.Frame.Clone();
        pictureBox1.Image = ScaleImage(tempBitmap, 640, 480);
        tempBitmap.Dispose();
    }
