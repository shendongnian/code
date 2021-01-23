    private void timer_Tick(object sender, EventArgs e)
    {    
        timer.Stop();
        try
        {
            timer.Interval = 5000; // Next time, wait 5 secs
            // Set the image and select next picture
            button1.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject(arr1[currentImageIndex]);
            currentImageIndex++;
        }
        finally
        {
            // Only start the timer if we have more images to show!
            if (currentImageIndex < arr1.Length)   
                timer.Start();
        }
    }
