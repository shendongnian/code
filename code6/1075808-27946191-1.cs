	private void TimerCallback(object sender, System.Timers.ElapsedEventArgs e)
	{
		const string baseString = "The event was raised at {0}";
		//signalTime is now of type DateTime and contains the value 
		//indicating when the timer's Elapsed event was raised
		var signalTime = e.SignalTime;
		//Create a new Action - delegate - which takes a string argument
		var setLabelText = new Action<DateTime>(dt =>
		{
			//If the amount of seconds in the dt argument is an even number,
			//set the timeLabel's forecolor to red; else, make it green
			timeLabel.ForeColor = dt.Second % 2 == 0 ? Color.Red : Color.Green;
			//Format the baseString to display the time in dt
			timeLabel.Text = string.Format(baseString, dt.ToLongTimeString());
		});
		//Check if we can access the control from this thread
		if (timeLabel.InvokeRequired) {
			//We can't access the label from this thread,
			//so we'll call invoke so it is executed from
			//the thread the it was created on
			timeLabel.Invoke(setLabelText, signalTime);
		}
		else {
			//The label's text can be set from this thread,
			//we'll just call the delegate without Invoke()
			setLabelText(signalTime);
		}
	}
