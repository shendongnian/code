    private void ProcessFrame(object sender, EventArgs arg)
    {
        //If you want to access the image data the use the following method call
        //Image<Bgr, Byte> frame = new Image<Bgr,byte>(_capture.RetrieveBgrFrame().ToBitmap());
        if (RetrieveBgrFrame.Checked)
        {
            Image<Bgr, Byte> frame = _capture.RetrieveBgrFrame();
            //because we are using an autosize picturebox we need to do a thread safe update
            if(frame!=null)
            { 
                 DisplayImage(frame.ToBitmap());
                 Image<Bgr, Byte> ImageFrame = frame.Resize(img.Width, img.Height,  Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR); 
                 // Here I am doing some other operations like 
                 // 1. Save Image captured from the IP Camera
                 // 2. Detect faces in Image 
                 // 3. Draw Face markers on Image
                 // 4. Some database based on result of Face Detection
                 // 4. Delete image File 
                 // continue Looping for other Ip Cameras  
            }
            //else do nothing as we have no image
        }
        else if (RetrieveGrayFrame.Checked)
        {
            Image<Gray, Byte> frame = _capture.RetrieveGrayFrame();
            //because we are using an autosize picturebox we need to do a thread safe update
            if (frame != null) DisplayImage(frame.ToBitmap());
        }
    }
