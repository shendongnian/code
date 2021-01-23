    var regVersion = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\TestApp\\1.0", true);
    if (regVersion == null) {
    	// Key doesn't exist; create it.
    	regVersion = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\TestApp\\1.0");
    }
    
    int intVersion = 0;
    if (regVersion != null) {
    	intVersion = regVersion.GetValue("Version", 0);
    	intVersion = intVersion + 1;
    	regVersion.SetValue("Version", intVersion);
    	regVersion.Close();
    }
