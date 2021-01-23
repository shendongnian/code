    	protected void clipboardSetText(string inTextToCopy)
		{
			var clipboardThread = new Thread(() => clipBoardThreadWorker(inTextToCopy));
			clipboardThread.SetApartmentState(ApartmentState.STA);
			clipboardThread.IsBackground = false;
			clipboardThread.Start();
		}
		private void clipBoardThreadWorker(string inTextToCopy)
		{
			System.Windows.Clipboard.SetText(inTextToCopy);
		}
