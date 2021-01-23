	public static void Main()
	{
		// Prepare the process.
		ProcessStartInfo startInfo = new ProcessStartInfo();
		startInfo.CreateNoWindow = false;
		startInfo.UseShellExecute = false;
		startInfo.FileName = "robocopy.exe";
		startInfo.WindowStyle = ProcessWindowStyle.Hidden;
		startInfo.Arguments = "WHATEVER YOU NEED"
		// Start process and wait for it to end
		Process exeProcess = Process.Start(startInfo)
		exeProcess.WaitForExit();
		// Display what the exit code was
		Console.WriteLine();
		Console.WriteLine("Process exit code: {0}", exeProcess.ExitCode);
	}
