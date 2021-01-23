	/// <summary>
	/// The Next button uses this to signal the BackgroundWorker
	/// to start the blocking call to Receive data
	/// </summary>
	private AutoResetEvent _SignalStartReceive  = new AutoResetEvent(false);
	/// <summary>
	/// To implement variable time it takes until Receive returns
	/// </summary>
	private Random _RandomTime = new Random();
	// Class Initializer
	public Form()
	{
		backgroundWorker_Receive.WorkerReportsProgress = true;
		backgroundWorker_Receive.RunWorkerAsync();
		return;
	}
	
	/// <summary>
	/// User presses this button when he is ready to Receive the next
	/// data packet
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void button_ReceiveNext_Click(object sender, EventArgs e)
	{
		checkBox_Receive.Checked = true;
		textBox_ReceivedContent.Text = "";
		_SignalStartReceive.Set();
		return;
	}
	/// <summary>
	/// User presses this button when he is ready to Receive the next
	/// data packet
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void button_ReceiveNext_Click(object sender, EventArgs e)
	{
		checkBox_Receive.Checked = true;
		textBox_ReceivedContent.Text = "";
		_SignalStartReceive.Set();
		return;
	}
	/// <summary>
	/// This is the worker thread, running in the background
	/// while the UI stays responsive
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void backgroundWorker_Receive_DoWork(object sender, DoWorkEventArgs e)
	{
		BackgroundWorker worker = sender as BackgroundWorker;
		while (true)
		{
			// blocking: wait for button click
			_SignalStartReceive.WaitOne();
			// blocking: wait for datagram over network
	#if true //temporary code to simulate UdpClient.Receive()
			DateTime StartTime = DateTime.Now;
			int RandomTimeMs = 2000 + 30 * _RandomTime.Next(100);
			Thread.Sleep(RandomTimeMs);
			_ReceivedDatagram = string.Format("UDP data ... {0} ms", (DateTime.Now - StartTime).TotalMilliseconds);
	#else
			something with UdpClient.Receive();
	#endif
			// succeeded:
			worker.ReportProgress(0);//fire the event: Receive_ProgressChanged (argument does not matter)
		}
		//return; //unreachable, but would fire the Completed event
	}
	/// <summary>
	/// Handler for the ReportProgress() call by the BackgroundWorker Thread
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void backgroundWorker_Receive_ProgressChanged(object sender, ProgressChangedEventArgs e)
	{
		textBox_ReceivedContent.Text = _ReceivedDatagram;
		checkBox_Receive.Checked = false;
		return;
	}
