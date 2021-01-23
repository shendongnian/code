    private volatile int _loadImageCount = 0;
    
    public void LoadImage_Click_1(object sender, RoutedEventArgs e)
    {
        _loadImageCount += 1;
    	if (_loadImageCount > 10)
    	{
            UpdateImage();
    	}
    	else
    	{
    	    UpdateRandomImage();
    	}
    }
    
    private void UpdateRandomImage()
    {
    	Random rand = new Random();
        int pic = rand.Next(1,0)
        myImage.Source = new BitmapImage(new Uri("ms-appx:///img/" + pic +".jpg"));
    }
    
    private void UpdateImage()
    {
    	...
    }
