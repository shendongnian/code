    private void ProcessFrame(object sender, EventArgs arg)
    {
        //If you want to access the image data the use the following method call
        //Image<Bgr, Byte> frame = new Image<Bgr,byte>(_capture.RetrieveBgrFrame().ToBitmap());
        if (RetrieveBgrFrame.Checked)
        {
            Image<Bgr, Byte> frame = _capture.RetrieveBgrFrame();
            //because we are using an autosize picturebox we need to do a thread safe update
            if(frame!=null) DisplayImage(frame.ToBitmap());
        }
        else if (RetrieveGrayFrame.Checked)
        {
            Image<Gray, Byte> frame = _capture.RetrieveGrayFrame();
            //because we are using an autosize picturebox we need to do a thread safe update
            if (frame != null) DisplayImage(frame.ToBitmap());
        }
    }
