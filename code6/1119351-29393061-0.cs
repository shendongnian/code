    //before loading the view
	public override void ViewWillAppear(bool animated)
    {
        ...
	    StartTimer();
	}
    // when view is loaded  
    public override void ViewDidLoad()
    {
        base.ViewDidLoad();
        ....
    	UpdateDateTime();
    }
	private void UpdateDateTime()
	{
		var dateTime = DateTime.Now;
		StartTimer.Text = dateTime.ToString("HH:mm:ss");
	}
	private void StartTimer()
	{
		var timer = new Timer(1000);//updates every second
		timer.Elapsed += (s, a) => InvokeOnMainThread(UpdateDateTime);
		timer.Start();
	}
