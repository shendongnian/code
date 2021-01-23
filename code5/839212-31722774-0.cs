    Process p = new Process();
	p.StartInfo.FileName = "sc.exe";
	p.StartInfo.Arguments = "queryex \"" + srv_name + "\"";
	p.StartInfo.UseShellExecute = false;
	p.StartInfo.RedirectStandardOutput = true;
	p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
	p.Start();
	p.WaitForExit();
	string output = p.StandardOutput.ReadToEnd();
	p.Close();
	if (output.IndexOf("SERVICE_NAME") != -1)
	{
		bool getPid = false;
		string[] words = output.Split(':');
		foreach (string word in words)
		{
			if (word.IndexOf("PID") != -1 && getPid == false)
			{
				getPid = true;
			}
			else if (getPid == true)
			{
				string[] pid = word.Split('\r');
				return Convert.ToInt32(pid[0]);
			}
		}
	}
