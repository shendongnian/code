    public static void MyMethod()
    {
		var rootKey = Registry.LocalMachine.OpenSubKey("SOFTWARE", true);
        using (var existingKey = rootKey.OpenSubKey("MyApp1", true))
        {
            existingKey.SetValue("target", "double new");
            existingKey.Close();
        }    
        
        rootKey.Close();
    }
	
