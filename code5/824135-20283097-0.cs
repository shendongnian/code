		private void ShowProgress()
		{
			ToggleForm();
			var loadForm = new Progressfrm();
			loadForm.ShowDialog();
			ToggleForm();
		}
		private void ToggleForm()
		{
			Enabled = !Enabled;
		}
        private void btnScrape_Click(object sender, EventArgs e)
        {
            ShowProgress();
        }
