    var cmd = new System.Diagnostics.Process
    {
        StartInfo =
        {
            FileName = "cmd.exe",
            WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
            RedirectStandardOutput = true,
            Arguments = "/C net time /DOMAIN:" + Environment.UserDomainName,
            UseShellExecute = false
        }
    };
    cmd.Start();
    string output = cmd.StandardOutput.ReadToEnd();
    if (output.EndsWith("The command completed successfully.\r\n\r\n"))
    {
        int is_index = output.IndexOf("is ");
        int serv_start = output.IndexOf(@"\\") + 2;
        int serv_end = is_index - 1;
        string time_server = output.Substring(serv_start, serv_end - serv_start).Split(new char[] { '.' })[0];
        if (time_server == Environment.MachineName)
            return DateTime.MaxValue; // local machine is acting as time server
                
        int time_start = is_index + 3;
        int time_end = output.IndexOf("\r");
        string local = output.Substring(time_start, time_end - time_start);
        return DateTime.ParseExact(local, "M/d/yyyy h:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture);
    }
    return DateTime.MaxValue;
