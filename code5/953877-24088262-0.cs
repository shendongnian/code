	private void button1_Click(object sender, EventArgs e)
	{
		// call the helper to do something
		Task.Factory.StartNew(() => { FakeSearch(); });
		//Generate the update the waiting text
		Task.Factory.StartNew(() => { updateWaiting(); });
	}
	private void FakeSearch()
	{
		_externalFlag = false;
		Thread.Sleep(5000);
		_externalFlag = true; // simulate completing the task
	}
	private bool _externalFlag = false;
	private void updateWaiting()
	{
		int count = 0;
		StringBuilder waitingText = new StringBuilder();
		 
		waitingText.Append("Finding stuff");
		int baseLen = waitingText.Length;
		while (!_externalFlag)
		{
			Thread.Sleep(1000); // time between adding dots
			if (count >= 3) // number of dots
			{
				waitingText.Remove(baseLen, count);
				count = 0;
			}
			waitingText.Append(".");
			count++;
			BeginInvoke(new Action( () => { updateText(waitingText.ToString()); }) );
		}
		BeginInvoke(new Action( () => { updateText("done"); }) );
	}
	private void updateText(string txt)
	{
		textBox1.Text = txt;
	}
