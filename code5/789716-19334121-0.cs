    using (var capture = new Emgu.CV.Capture())
    {
    	int numFrames = ...;
    	for (int i = 0; i < numFrames; i++)
    	{
    		using (var ImageFrame = capture.QueryFrame())
    		{
    			if (ImageFrame != null)
    			{
    				ImageFrame.Save(String.Format(@"C:\Users\crowds\Documents\Example\Sample{0}.jpg", i));		
    			}	
    		}
    	}
    }
