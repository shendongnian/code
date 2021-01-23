        private void mnuPropertyPages_Click(object sender, System.EventArgs e)
		{
			try
			{
				MenuItem m = sender as MenuItem;
				capture.PropertyPages[m.Index].Show( this );
				updateMenu();
			}
			catch (Exception ex)
			{ 
				MessageBox.Show( "Unable display property page. Please submit a bug report.\n\n" + ex.Message + "\n\n" + ex.ToString() );
			}
		}
