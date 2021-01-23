	private void bw_DoWork(object sender, DoWorkEventArgs e)
	{
		BackgroundWorker worker = sender as BackgroundWorker;
		App.ViewModel.LoadData().Wait();
		System.Threading.Thread.Sleep(3000);
	}
