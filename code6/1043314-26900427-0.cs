	// assign one (two parameters) method as a .NET event
	btnSubmit.TouchUpInside += TouchUpInsideEvent;
	...
	// call another (one parameter) method like a selector
	any_nsobject.PerformSelector (new Selector ("TouchUpInsideEvent:"), sender as NSObject, 0f);
	...
	
	// have the 2 parameters method call the(1 parameter) export'ed method
	private void TouchUpInsideEvent (object sender, EventArgs e)
	{
		TouchUpInsideEvent (sender as NSObject);
	}
	[Export ("TouchUpInsideEvent:")]
	private void TouchUpInsideEvent (NSObject sender)
	{
		Console.WriteLine ("yay!");
	}
