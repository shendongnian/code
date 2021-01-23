    	private bool isMainFormClosed = false;
		
		private void showMainForm()
		{
			// Hide the loginform UI.
			this.Hide();
			
			var mainForm = new MainForm();
			
			// Creating close event for mainform, whenever close icon is clicked it will close the login form which is hided.
			mainForm.FormClosed += new FormClosedEventHandler(mainFormClosed);
			
			// Show the mainform UI
			mainForm.Show();
		}
		
		private void mainFormClosed(object sender, FormClosedEventArgs e)
		{
			this.isMainFormClosed = true;
			
			this.Close();
		}
		
		private void loginFormClosing(object sender, FormClosingEventArgs e)
		{	
			if(!this.isMainFormClosed)
			{
				DialogResult dialogResult = MessageBox.Show("Do you want to close the application",AppConstants.APPLICATION_NAME,
				                                            MessageBoxButtons.YesNo,MessageBoxIcon.Question);
				
				if(dialogResult == DialogResult.No)	
					e.Cancel = true;
			}
		}
