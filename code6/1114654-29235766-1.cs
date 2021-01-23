    //Convert stream to image then to bitmap
    Bitmap bmpImage = new Bitmap(System.Drawing.Image.FromStream(stream));                    
    //Convert to emgu image (desired goal)
    currentFrame = new Emgu.CV.Image<Bgr, Byte>(bmpImage);
    
    //gray scale for later use
    gray = currentFrame.Convert<Gray, Byte>();
    SaveToBuffer(gray);
    
    Queue<Emgu.CV.Image<Gray, Byte>> buffer = new Queue<Emgu.CV.Image<Gray, Byte>>();
    bool canProcess = false;
    // ...
    private void SaveToBuffer(Emgu.CV.Image<Gray, Byte> img)
    {
     	buffer.Enqueue(img);
     	canProcess = buffer.Count > 100;
    }
    
    private void Process()
    {
    	if(canProcess)
    	{
            buffer.Dequeue();
    		// Processing logic goes here...
    	}
    	else
    	{
    		// Buffer is still loading...
    	}
    }
