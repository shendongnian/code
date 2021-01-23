	public partial class App
	{
		protected override void OnStartup(System.Windows.StartupEventArgs e)
		{
			base.OnStartup(e);
			
			if (!AreSettingsSet())
			{
				this.MainWindow = new Login();
				this.MainWindow.ShowDialog(); // Waits until closed.
				
				// Recheck the settings now that the login screen has been closed.
				if (!AreSettingsSet())
				{
					// Tell the user there is a problem and quit.
					this.Shutdown();
				}
			}
			this.MainWindow = new MainWindow();
			this.MainWindow.Show();
		}
		
		private bool AreSettingsSet()
		{
			// Whatever you need to do to decide if the settings are set.
		}
	}
	
