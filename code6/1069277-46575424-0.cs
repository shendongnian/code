	public partial class About : Page, IPostBackEventHandler
	{
		protected void Page_Init(object sender, EventArgs e)
		{
			// Unless the button is serverside clicking it will reload the page
			// registering the page like this prevents a page reload.
			var scriptManager = ScriptManager.GetCurrent(Page);
			scriptManager?.RegisterAsyncPostBackControl(Page);
		}
		/// <inheritdoc />
		public void RaisePostBackEvent(string eventArgument)
		{
			var javascriptCode = $"alert('server method called and triggered client again. {DateTime.Now.ToString("s")}');";
			// if your key isn't changed this script will only execute once
			ScriptManager.RegisterStartupScript(udpMain, typeof(UpdatePanel), Guid.NewGuid().ToString(), javascriptCode, true);
			// updating the updatepanel will inject your script without reloading anything else
			udpMain.Update();
		}
	}
