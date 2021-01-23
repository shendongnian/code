        private ProgressBar _progressBar;
		private void Progressfrm_Shown(object sender, EventArgs e)
		{
			_progressBar = new ProgressBar { Size = new Size(100, 20), Location = new Point(10, 10) };
			Controls.Add(_progressBar);
			_progressBar.Show();
			Refresh();
			LoadProgress();
		}
		private void LoadProgress()
		{
			while (_progressBar.Value < 100)
			{
				_progressBar.Value++;
				Thread.Sleep(100);
			}
			Close();
		}
    
