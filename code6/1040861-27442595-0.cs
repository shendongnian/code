		BackgroundWorker bgw;
		public MainWindow()
		{
			InitializeComponent();
			bgw = new BackgroundWorker();
			bgw.DoWork += new DoWorkEventHandler(bgw_DoWork);
			bgw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgw_RunWorkerCompleted);
			bgw.WorkerReportsProgress = true;
			bgw.ProgressChanged += new ProgressChangedEventHandler(bgw_ProgressChanged);
		}
        // Starting the time consuming operation
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			bgw.RunWorkerAsync();
		}
        // using the ProgressChanged-Handler to execute the user interaction
		void bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			UserStateData usd = e.UserState as UserStateData;
            // UserStateData.Message is used to see **who** called the method
			if (usd.Message == "X")
			{
                // do the user interaction here
				UserInteraction wnd = new UserInteraction();
				wnd.ShowDialog();
                // A global variable to carry the information and the EventWaitHandle
				Controller.instance.TWS.Message = wnd.TextBox_Message.Text;
				Controller.instance.TWS.Background.Set();
			}
		}
		void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			MessageBox.Show(e.Result.ToString());
		}
        // our time consuming operation
		void bgw_DoWork(object sender, DoWorkEventArgs e)
		{
			Thread.Sleep(2000);
            // need 4 userinteraction: raise the ReportProgress event and Wait
			bgw.ReportProgress(0, new UserStateData() { Message = "X", Data = "Test" });
			Controller.instance.TWS.Background.WaitOne();
            // The WaitHandle was released, the needed information should be written to global variable
			string first = Controller.instance.TWS.Message.ToString();
            // ... and again
			Thread.Sleep(2000);
			bgw.ReportProgress(0, new UserStateData() { Message = "X", Data = "Test" });
			Controller.instance.TWS.Background.WaitOne();
			e.Result = first + Controller.instance.TWS.Message;
		}
