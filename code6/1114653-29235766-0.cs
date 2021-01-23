    //Convert stream to image then to bitmap
    Bitmap bmpImage = new Bitmap(System.Drawing.Image.FromStream(stream));                    
    //Convert to emgu image (desired goal)
    currentFrame = new Emgu.CV.Image<Bgr, Byte>(bmpImage);
    
    //gray scale for later use
    gray = currentFrame.Convert<Gray, Byte>();
    SaveToBuffer(gray);
    
    List<Emgu.CV.Image<Gray, Byte>> buffer = new List<Emgu.CV.Image<Gray, Byte>>();
    bool canProcess = false;
    // ...
    private void SaveToBuffer(Emgu.CV.Image<Gray, Byte> img)
    {
     	buffer.Add(img);
     	canProcess = buffer.Count > 100;
    }
    
    private void Process()
    {
    	if(canProcess)
    	{
    		// Processing logic goes here...
    	}
    	else
    	{
    		// Buffer is still loading...
    	}
    }
