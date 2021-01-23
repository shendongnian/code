    DateTime lastTap;
    int numTaps;
    TimeSpan tapRate; // initialize from Windows.UI.ViewManagement.UISettings.DoubleClickTime
	
    void gestureRecognizer_Tapped(Windows.UI.Input.GestureRecognizer sender, Windows.UI.Input.TappedEventArgs args)
    {
    	if (DateTime.Now < lastTap + tapRate)
    	{
    		numTaps++;
    	}
    	else
    	{
    		numTaps = 1;
    	}
    	lastTap = DateTime.Now;
    	TxtGestureNotes.Text = string.Format("Tap gesture {0} recognized", numTaps);
    }
