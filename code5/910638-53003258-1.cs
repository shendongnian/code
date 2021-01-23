	public void Whatever()
	{
		if (con.State == ConnectionState.Open)
            {
				/// Your code
			}
		else
		{
		    MessageBox.Show("Could not connect to server", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
            OpenConnection();
		}
	}
