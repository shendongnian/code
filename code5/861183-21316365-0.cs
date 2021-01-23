	public partial class FastForwardForm : Form
	{
		private Exception asyncError;
		public event DoWorkEventHandler DoWork
		{
			add { worker.DoWork += value; }
			remove { worker.DoWork -= value; }
		}
		public FastForwardForm()
		{
			InitializeComponent();
		}
		public Exception AsyncError
		{
			get { return asyncError; }
		}
		private void FastForwardForm_Shown(object sender, EventArgs e)
		{
			worker.RunWorkerAsync();
		}
		private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			progressBar.Value = e.ProgressPercentage;
			statusLabel.Text = e.UserState.ToString();
		}
		private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (e.Error != null) asyncError = e.Error;
			HideProgressForm();
			worker.Dispose();
		}
		private void HideProgressForm()
		{
			//not actually needed, the callback runs on the UI thread.
			if (InvokeRequired)
			{
				Invoke((Action)HideProgressForm);
				return;
			}
			Close();
		}
	}
