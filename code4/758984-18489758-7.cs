    private void def(object sender, EventArgs e)
    {
		//if you need to check that the setting exists use this 
		//if (IsolatedStorageSettings.ApplicationSettings.Contains("qsPage"))
		//retrieve tha value from the settings
                var page = IsolatedStorageSettings.ApplicationSettings["qsPage"];
           		
        switch(page)
        {
        \\...
        }
    }
