    ...
	public MainWindow()
	{
		InitializeComponent();
		
		//--init main windows minimized
		WindowState = System.Windows.WindowState.Minimized;
		
		Loaded +=
			delegate
			{
				//hide main window
				Hide();
				//initialize the login window
				var loginWin = new LoginWindow
				{
					WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen,
					WindowStyle = System.Windows.WindowStyle.SingleBorderWindow,
				};
				loginWin.Closed += delegate
				{
					//check login result (OK)
					if (loginWin.Result != LoginResult.Success)
						Application.Current.Shutdown(1);
					//--display the main window
					Show();
					WindowState = System.Windows.WindowState.Normal;
					Focus();
				};
				//show&focus the login
				loginWin.Show();
				loginWin.Focus();
			};
	}
	...
