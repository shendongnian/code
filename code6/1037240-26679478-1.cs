    try
    {   
         ProcessStartInfo procStartInfo = new ProcessStartInfo(yourFilePath, yourArgument);
         procStartInfo.RedirectStandardOutput = true;
         procStartInfo.RedirectStandardError = true;
         procStartInfo.UseShellExecute = false;
         Process proc = new Process();
         proc.StartInfo = procStartInfo;
         proc.Start();
    }
    catch (Exception e)
    {
        Console.WriteLine(e.ToString());
    }
