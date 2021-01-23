    System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo();
    psi.FileName = @"C:\Windows\System32\cmd.exe";
    psi.RedirectStandardOutput = true;
    psi.RedirectStandardError = true;
    psi.RedirectStandardInput = true;
    psi.UseShellExecute = false;
    psi.CreateNoWindow = true;
    
    System.Diagnostics.Process p = new Process();
    p.StartInfo = psi;
    p.OutputDataReceived += p_DataReceived;
    p.EnableRaisingEvents = true;
    p.Start();
    p.BeginOutputReadLine();
    p.BeginErrorReadLine();
    
    p.StandardInput.WriteLine("adb devices");
    p.StandardInput.WriteLine("exit");
    p.WaitForExit();
    
    static void p_DataReceived(object sender, DataReceivedEventArgs e)
    {
    // Manipulate received data here
            Console.WriteLine(e.Data);
    // if no devices, then there will be only "List of devices attached: "
    }
