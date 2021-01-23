     System.Diagnostics;
    	var processStartInfo = new ProcessStartInfo
        {
            CreateNoWindow = true,
            RedirectStandardOutput = true,
            RedirectStandardInput = true,
            UseShellExecute = false,
            Arguments = "your.js plus any arguments here",
            FileName = "path/to/phantomjs.exe"
        };
        var process = new Process
        {
            StartInfo = processStartInfo,
            EnableRaisingEvents = true
        };
        //pipe the output
        process.OutputDataReceived += (sender, args) => {
        	//args.Data has output from phantomjs
        };
       
            process.Start();
            process.BeginOutputReadLine();
            process.WaitForExit(20000);
            process.CancelOutputRead();
       
