    string arguments = "-mx3 -m0=LZMA2";
    System.Diagnostics.Process process = new System.Diagnostics.Process();
    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
    startInfo.FileName = sevenZip;
    startInfo.Arguments = arguments;
    process.StartInfo = startInfo;
    process.Start();
    process.WaitForExit();
