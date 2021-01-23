    timer.Stop();
    try
    {
        timer.Interval = 5000; // Next time, wait 5 secs
        button1.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject(arr1[currentImageIndex]);
        currentImageIndex++;
    }
    finally
    {
        if (currentImageIndex < arr1.Length)   
            timer.Start();
    }
