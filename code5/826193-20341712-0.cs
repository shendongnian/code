	static class CommandRunner
	{
		static StringBuilder cmdOutput = new StringBuilder();
		public static string Run(string command)
		{
			if (string.IsNullOrWhiteSpace(command))
				return null;
			using (var proc = new Process())
			{
				proc.StartInfo.FileName = Path.Combine(Environment.GetEnvironmentVariable("WINDIR"), "System32", "cmd.exe");
				proc.StartInfo.Arguments = "/c " + command;
				proc.StartInfo.LoadUserProfile = false;
				proc.StartInfo.CreateNoWindow = true;
				proc.StartInfo.RedirectStandardOutput = true;
				proc.StartInfo.RedirectStandardError = true;
				proc.StartInfo.UseShellExecute = false;
				proc.EnableRaisingEvents = true;
				proc.OutputDataReceived += proc_DataReceived;
				proc.ErrorDataReceived += proc_DataReceived;
				try
				{
					proc.Start();
					proc.BeginErrorReadLine();
					proc.BeginOutputReadLine();
					proc.WaitForExit();
				}
				catch (Exception e)
				{
					cmdOutput.AppendLine("***Exception during command exection***");
					cmdOutput.AppendLine(e.Message);
					cmdOutput.AppendLine("*** ***");
				}
			}
			return cmdOutput.ToString();
		}
		static void proc_DataReceived(object sender, DataReceivedEventArgs e)
		{
			if (e.Data != null)
				cmdOutput.AppendLine(e.Data);
		}
	}
