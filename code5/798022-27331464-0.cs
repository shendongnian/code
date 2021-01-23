    static void Main(string[] args)
    {
        System.Diagnostics.Process process2 = new System.Diagnostics.Process();
        System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
        startInfo.FileName = "cmd.exe";
        startInfo.Arguments = "/C NET USE F: /delete";
        startInfo.RedirectStandardError = true;
        startInfo.RedirectStandardInput = true;
        startInfo.RedirectStandardOutput = true;
        startInfo.UseShellExecute = false;
        startInfo.CreateNoWindow = true;
        process2.StartInfo = startInfo;
        process2.Start();
        Read(process2.StandardOutput);
        Read(process2.StandardError);
        while (true)
            process2.StandardInput.WriteLine("Y");
        
    }
    private static void Read(StreamReader reader)
    {
        new Thread(() =>
        {
            while (true)
            {
                int current;
                while ((current = reader.Read()) >= 0)
                    Console.Write((char)current);
            }
        }).Start();
    }
