    using (Process p = new Process())
    {
    	p.StartInfo.FileName = "filename.exe";
    	p.StartInfo.Arguments = "params";
    	p.StartInfo.UseShellExecute = false; // use CreateProcess
    	p.StartInfo.RedirectStandardOutput = true; // get stdout
    	p.StartInfo.RedirectStandardError = true;  // get stderr
    	p.StartInfo.CreateNoWindow = true;
    
    	p.Start();
    
    	string line;
    	while (!p.StandardOutput.EndOfStream)
    	{
    		line = p.StandardOutput.ReadLine();
    		Console.WriteLine(line);
    	}
    
    	if (!p.StandardError.EndOfStream)
    	{
    		Console.WriteLine("Error: " + p.StandardError.ReadToEnd());
    	}
    
    }
