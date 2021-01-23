    private void camera_NewFrame(object sender, ref Bitmap image)
    {
        pictureBox1.Image = image;
    
        if (backgroundWorker1.IsBusy != true)
        {
            lock (locker)
            {
                if (inputImage != null)
                    inputImage.Dispose();
                inputImage = (Bitmap)image.Clone();
            }
            backgroundWorker1.RunWorkerAsync();
        }
    }
    
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        // Do Image processing here
        // show result in pictureBox2
    }
