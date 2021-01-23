    using(Process proc = new Process())
    {
    	proc.StartInfo.UseShellExecute = false;
    	proc.StartInfo.FileName = <your exe>;
    	proc.StartInfo.Arguments = <your parameters>;
    	proc.StartInfo.RedirectStandardOutput = true;
    	proc.OutputDataReceived += LogOutputHandler;
    	proc.Start();
    	proc.BeginOutputReadLine();
    	proc.WaitForExit();
    }
    private static void LogOutputHandler(object proc, DataReceivedEventArgs outLine)
    {
    	<write your result to a file here>
    }
