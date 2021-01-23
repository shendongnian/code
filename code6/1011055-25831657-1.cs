	void DoRequest(object data)
	{
        // Get your command information from the input object.
		ScreenshotRequest.DannysCommands cmd = (ScreenshotRequest.DannysCommands)data;
		progressBar1.Invoke(new MethodInvoker(delegate()
			{
				if (progressBar1.Value < progressBar1.Maximum)
				{
					progressBar1.PerformStep();
					_captureProcess.BringProcessWindowToFront();
					// Initiate the screenshot of the CaptureInterface, the appropriate event handler within the target process will take care of the rest
					_captureProcess.CaptureInterface.BeginGetScreenshot(new Rectangle(int.Parse(txtCaptureX.Text), int.Parse(txtCaptureY.Text), int.Parse(txtCaptureWidth.Text), int.Parse(txtCaptureHeight.Text)), new TimeSpan(0, 0, 2), Callback,cmd);
				}
				else
				{
					end = DateTime.Now;
					txtDebugLog.Text = String.Format("Debug: {0}\r\n{1}", "Total Time: " + (end-start).ToString(), txtDebugLog.Text);
				}
			})
		);
	}
