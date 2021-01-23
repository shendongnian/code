    ProcessStartInfo si= new processStartInfo();
    si.fileName="c:\folder\some.exe";
    si.CreateNoWindow = false;
    si.UseShellExecute = false;
   
    si.WindowStyle = ProcessWindowStyle.Hidden;
    si.arguments="arguments here";
    try
        {
            // Start the process with the info we specified.
            // Call WaitForExit and then the using statement will close.
            using (Process exeProcess = Process.Start(si))
            {
            exeProcess.WaitForExit();
            }
        }
        catch
        {
            // Log error.
        }
