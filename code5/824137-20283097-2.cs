		private Progressfrm _loadForm;
		private void ShowProgress()
		{
			ToggleForm();
			_loadForm = new Progressfrm();
			_loadForm.ShowDialog();
			var tcheck = new Thread(CheckLoadedProgress);
			tcheck.Start();
			//do stuff here
		}
		private void CheckLoadedProgress()
		{
			while (_loadForm.IsAccessible) { }
			ToggleForm();
		}
		private void ToggleForm()
		{
			Invoke(new Action(() => Enabled = !Enabled));
		}
		private void btnScrape_Click(object sender, EventArgs e)
		{
			var tform = new Thread(ShowProgress);
			tform.Start();
		}
