    private void button4_Click(object sender, EventArgs e)
    {
        var capture = new Emgu.CV.Capture();
    
        using (var ImageFrame = capture.QueryFrame())
        {
            if (ImageFrame != null)
            {
                lastSaveCount++
                pictureBox1.Image = ImageFrame.ToBitmap();
                var filename = string.Format(@"C:\Users\crowds\Documents\Example\Sample{0}.jpg", lastSaveCount);
                ImageFrame.Save(filename);
    
            }
            _capture.Dispose();
        }
    }
