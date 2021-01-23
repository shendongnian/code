    string hostname = "hostname";
    string login = "login";
    string password = "password";
    var startInfo = new ProcessStartInfo();
    startInfo.FileName = @"C:\Putty\plink.exe";
    startInfo.RedirectStandardInput = true;
    startInfo.RedirectStandardOutput = true;
    startInfo.UseShellExecute = false;
    startInfo.Arguments = string.Format("{0}@{1} -pw {2}",
                                            login, hostname, password);
    using (var process = new Process {StartInfo = startInfo})
    {
        process.Start();
        process.StandardInput.WriteLine("ls");
        process.StandardInput.WriteLine("echo 'run more commands here...'");
        process.StandardInput.WriteLine("exit"); // make sure we exit at the end
        string output = process.StandardOutput.ReadToEnd();
        Console.WriteLine(output);
    }
