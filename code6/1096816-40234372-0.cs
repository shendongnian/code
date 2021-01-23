    /// <summary>
    /// The main entry point for the application.
	/// </summary>
	[STAThread]
	static void Main() 
	{
		AppDomain currentDomain = AppDomain.CurrentDomain;
		//Application.Run(new CaptureTest());
		Application.Run(new QuickTest());
	}
