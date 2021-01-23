     string asciiQuote = Char.ConvertFromUtf32(34);               
     ExecuteCommand("cmd.exe", "/c exit | sqlplus -S " + dbLink + " @" + asciiQuote + tobeExecutedSQLFile + asciiQuote + " > " + asciiQuote + resultTextFilePath + asciiQuote);
    
    
    public  string ExecuteCommand(string app, string command)
    {
    	System.Diagnostics.Process process = new System.Diagnostics.Process();
    	System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
    	startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
    	startInfo.FileName = app;            
    	startInfo.Arguments = command;
    	startInfo.CreateNoWindow = true;
    	startInfo.UseShellExecute = false;
    	process = Process.Start(startInfo);    
    	while (process.HasExited == false)
    	{    
    		//process.WaitForExit();               
    	}               
    	return "Executed";    	
    }
