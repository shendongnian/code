	in WebServer.cs:
		public event EventHandler UploadRequested;
		private void OnUploadRequested()
		{
			EventHandler handler = UploadRequested;
			if (handler != null)
				handler(this, EventArgs.Empty);
		}
		...
		// instead of calling UploadThat directly
		OnUploadRequested();
	in MainPage.cs:
		WebServer ws = new WebServer();
		ws.UploadRequested += ws_UploadRequested;
		...
		private void ws_UploadRequested(object sender, EventArgs e)
		{
			UploadThat();
		}
