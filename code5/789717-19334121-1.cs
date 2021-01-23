    private int filenumber = 0;
    
    private void button4_Click(object sender, EventArgs e)
    {	
    	using (var capture = new Emgu.CV.Capture())
    	using (var ImageFrame = capture.QueryFrame())
    	{
    		if (ImageFrame != null)
    		{
    			pictureBox1.Image = ImageFrame.ToBitmap();
    			ImageFrame.Save(String.Format(@"C:\Users\crowds\Documents\Example\Sample{0}.jpg", filenumber++));		
    		}	
    	}
    }
