	public async void MyButton_Click(object sender, EventArgs e)
	{
	    await CreateEthernetLink();
	    this.logger.Log("Connected!");
	}
 
	private async Task CreateEthernetLink()
	{ 
	    try
		{
			RMCLink rmc = RMCLink.CreateEthernetLink(DeviceType.RMC70, "192.168.0.55");
			RMC.Connect();
		}
		catch
		{
			this.logger.Log("Failed to connect");
		}
	 }
