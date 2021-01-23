		private void btnDataStuff_Click(object sender, EventArgs e)
		{
			try
			{
				ProcessSomeData();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message);
				MessageBox.Show("Inner exception: " + ex.InnerException.Message);
			}
		}
		private void ProcessSomeData()
		{
			try
			{
				// Code where NullReferenceException exception happens
			}
			catch (NullReferenceException ex)
			{
				throw new Exception("Data is null!!!", ex);
			}
		}
