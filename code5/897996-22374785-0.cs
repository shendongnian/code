    private void ProcessFrame(object sender, EventArgs e)
    {
        //Cap = new Emgu.CV.Capture();
        ImageFrame = Cap.QueryFrame();
        //Look for image content if null do nothing
        if(ImageFrame != null)
        {
            pictureBoxCapture.Image = ImageFrame.ToBitmap();
            //do any other operations on the image
        }
    }
