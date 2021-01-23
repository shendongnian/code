	private Process process = null;
	private DataReceivedEventHandler TheDataReceievedEventHandler;
	private void startProcess()
	{
		ProcessStartInfo processStartInfo = new ProcessStartInfo(@"cmd.exe", @"/C php artisan queue:listen --tries=3 --timeout=0 --memory=1024")
		{
			CreateNoWindow = true,
			UseShellExecute = false,
			RedirectStandardOutput = true,
			RedirectStandardError = true,
			WorkingDirectory = @"C:/xampp/htdocs/phpproject",
		};
		if ((process = Process.Start(processStartInfo)) != null)
		{
			process.EnableRaisingEvents = true;
			process.Exited += new EventHandler(ExitedHandler);
			TheDataReceievedEventHandler = new DataReceivedEventHandler(StandardOutputHandler);
			process.OutputDataReceived += TheDataReceievedEventHandler;
			process.BeginOutputReadLine();
			process.ErrorDataReceived += TheDataReceievedEventHandler;
			process.BeginErrorReadLine();
		}
	}
	private void ExitedHandler(object sender, EventArgs e)
	{
		throw new NotImplementedException(); // the service you're trying to run closed it self.
	}
	private void StandardOutputHandler(object sender, DataReceivedEventArgs e)
	{
		Console.WriteLine(e.Data);
	}
