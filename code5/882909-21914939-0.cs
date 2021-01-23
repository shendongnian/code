	public List<BGWOProcess> messageQueue = new List<BGWOProcess>();
	public static bool DialogOpen = false;
	public static bool CancelPending = false;
	
	public void loginProcess_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		BGWOProcess result = (BGWOProcess)e.Result;
		if (!result.Result)
		{
			if (CancelPending) return;
			if (!DialogOpen) DialogOpen = true;
			else
			{
				messageQueue.Add(result);
				return;
			}
			try
			{
				processFailedMessage(result);
			}
			catch (Exception) { }
			DialogOpen = false;
		}
		else
		{
			//...
		}
	}
	public void processFailedMessage(BGWOProcess result)
	{
		MyMessage msg = new MyMessage("The process " + result.Label + " failed: " + result.Error + " Retry?");
		if (msg.ShowDialog(this) == System.Windows.Forms.DialogResult.Yes)
		{
			// Retry request.
			Queue(result.func, result.Label, result.progressIncrement);
			if (messageQueue.Count > 0)
			{
				BGWOProcess nextMessage = messageQueue[0];
				messageQueue.Remove(nextMessage);
				processFailedMessage(nextMessage);
			}
		}
		else
		{
			r = false;
			CancelPending = true;
			// Fail.
			DialogResult = System.Windows.Forms.DialogResult.Abort;
		}
	}
