	private void Name_LostFocus(object sender, System.EventArgs e)
	{
		var textBox = sender as TextBox;
		//No longer Using BW since Ping.SendAsync() does the job
		PCIsOnline(textBox.Text); 
	}
	private void Search_SelectChanged(object sender, SelectionChangedEventArgs e)
	{
		ListBox Search = sender as ListBox;
		if (Search.SelectedValue != null)
		{
			this.OldName.Text = Search.SelectedValue.ToString();
			PCIsOnline(this.OldName.Text);
		}
	}
	public void PCIsOnline(string arg)
	{
		Ping pingSender = new Ping();
		//Sending argument to perform check later
		pingSender.PingCompleted += (sender1, args) => PingCompletedCallback(sender1, args, arg);
		PingOptions options = new PingOptions();
		options.DontFragment = true;
		string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
		byte[] buffer = Encoding.ASCII.GetBytes(data);
		int timeout = 5;
		pbrTest.Visibility = System.Windows.Visibility.Visible;
		pingSender.SendAsync(arg, timeout, buffer, options);
	}
	private void PingCompletedCallback(object sender, PingCompletedEventArgs e, String Current)
	{
		if (e.Cancelled)
		{
			HandleReply(null, Current, "Cancelled");
			return;
		}
		if (e.Error != null)
		{
			HandleReply(null, Current, "Error");
			return;
		}
		PingReply reply = e.Reply;
		HandleReply(reply, Current, "");
	}
	private void HandleReply(PingReply reply, String PC, String msgtype = "")
	{
		//Ignore old result I only need one that is in OldName textBox
		if (PC != this.OldName.Text) { return; }
		//Next you should add your result handling
		//Happens on a error
		if (reply == null)
		{
			/*do something*/
		}
		//PC is online
		else if (reply.Status == IPStatus.Success)
		{
			/*do something*/
		}
		//PC is offline
		else
		{
			/*do something*/
		}
	}
