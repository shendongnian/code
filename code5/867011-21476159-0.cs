    // MainPage.xaml.cs
    public void SetBrush(VideoBrush brush)
	{
		cameraBrush = brush;
	}
	
	
	// appdataInterface.cs
	public appdataInterface(MainPage page)
	{
		_page = page;
	}
	
	// later on
	_page.SetBrush(videoBrush);
