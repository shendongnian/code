		public static string Remote(string target, string command, string peFlags = "-e -s")
		{
			if (string.IsNullOrWhiteSpace(command))
				return null;
			using (var proc = new Process())
			{
				proc.StartInfo.FileName = @"C:\PSTools\PSExec.exe";
				proc.StartInfo.Arguments = string.Format(@"\\{0}{1} cmd.exe ""/c {2}""", target, peFlags == null ? "" : " " + peFlags, command);
				proc.StartInfo.LoadUserProfile = false;
				proc.StartInfo.CreateNoWindow = true;
				proc.StartInfo.RedirectStandardOutput = true;
				proc.StartInfo.UseShellExecute = false;
				proc.EnableRaisingEvents = true;
				proc.OutputDataReceived += proc_DataReceived;
				try
				{
					proc.Start();
					proc.BeginOutputReadLine();
					proc.WaitForExit();
				}
				catch 
				{ }
			}
			return cmdOutput.ToString();
		}
