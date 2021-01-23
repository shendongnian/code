    private void Form1_Load(object sender, EventArgs e)
    {            
        
        var capture = new Emgu.CV.Capture();
        using (var nextFrame = capture.QueryFrame())
        {
            if (nextFrame != null)
            {                           
                pictureBox1.Image = nextFrame.ToBitmap();
            }
        }                         
    }
