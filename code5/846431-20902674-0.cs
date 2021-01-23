    using Emgu.CV;
    using Emgu.CV.Structure;
    
    Class Movie
    {
       private Capture capture;
       public Movie(string fileName)
       {
         capture = new Capture(fileName);
         ...
       }
       public Image<Bgr, byte> GetFrame(double frameNum)
       {
            capture.SetCaptureProperty(CAP_PROP.CV_CAP_PROP_POS_FRAMES, frameNum);
            return capture.QueryFrame();
       }
    }
