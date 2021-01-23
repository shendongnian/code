    private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
    {
        Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
        this.Invoke((MethodInvoker)delegate
        {
            pictureBox1.Image = bitmap;
            pictureBox1.Refresh();
        });      
    }
        
