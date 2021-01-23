    if (CurrentState == VideoMethod.Viewing)
    {
        frame = _Capture.RetrieveBgrFrame();
        if (frame != null)
        {
            using (Image<Gray, Byte> gray = frame.Convert<Gray, Byte>()) //Convert it to Grayscale
            {
                //normalizes brightness and increases contrast of the image
                gray._EqualizeHist();
                //Detect the faces  from the gray scale image and store the locations as rectangle
                //The first dimensional is the channel
                //The second dimension is the index of the rectangle in the specific channel
                Rectangle[] facesDetected = face.DetectMultiScale(
                                   gray,
                                   1.1,
                                   10,
                                   new Size(20, 20),
                                   Size.Empty);
                foreach (Rectangle f in facesDetected)
                {
                    //Draw the rectangle on the frame
                    frame.Draw(f, new Bgr(Color.Red), 2);
                }
            }
            
            //Show image
            DisplayImage(frame.ToBitmap());
        }
    }
