    System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo(yourCmd, yourCmdArguments);
    psi.RedirectStandardOutput = false;
    psi.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
    psi.UseShellExecute = true;
    System.Diagnostics.Process externalProcess;
    externalProcess = System.Diagnostics.Process.Start(psi);
    externalProcess.WaitForExit();
