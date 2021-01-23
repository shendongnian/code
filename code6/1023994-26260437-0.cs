    static void Main(string[] args)
    {
        System.Diagnostics.Process process = new System.Diagnostics.Process();
        System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
        // the cmd program
        startInfo.FileName = "cmd.exe";
        // set my arguments. date is just a dummy example. the real work isn't use date.
        startInfo.Arguments = "/c date";
        startInfo.RedirectStandardOutput = true;
        startInfo.UseShellExecute = false;
        process.StartInfo = startInfo;
        process.Start();
        // capture what is generated in command prompt
        var output = process.StandardOutput.ReadToEnd();
        // write output to console
        Console.WriteLine(output);
        process.WaitForExit();
        Console.Read();
    }
