    Process p = Process.GetCurrentProcess();
    p.UseShellExecute = false;
    p.RedirectStandardOutput = true;
    using (StreamReader reader = process.StandardOutput)
	{
	    string result = reader.ReadToEnd();
	    Console.Write(result);
	}
