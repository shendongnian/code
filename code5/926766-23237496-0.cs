    var command = "dir";
    System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + command);
    procStartInfo.RedirectStandardOutput = true;
    procStartInfo.UseShellExecute = false;
    System.Diagnostics.Process proc = new System.Diagnostics.Process();
    proc.StartInfo = procStartInfo;
    proc.Start();
    string result = proc.StandardOutput.ReadToEnd();
    Console.WriteLine(result);
