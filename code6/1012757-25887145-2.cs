	private static void startProgram(
		string commandLine )
    {
		var fileName = commandLine;
		var arguments = string.Empty;
		checkSplitFileName( ref fileName, ref arguments );
		var info = new ProcessStartInfo();
		info.FileName = fileName;
		info.Arguments = arguments;
		info.UseShellExecute = false;
		info.RedirectStandardOutput = true;
		info.RedirectStandardError = true;
		using ( var p = new Process() )
		{
			p.StartInfo = info;
			p.EnableRaisingEvents = true;
			p.OutputDataReceived += (s,o) => { 
				Console.WriteLine(o.Data);
			};
			p.Start();
			p.BeginOutputReadLine();
			p.WaitForExit();
		}
    }
