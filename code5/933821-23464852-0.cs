    Process process = new Process();
    process.StartInfo.FileName = @"C:\bin\run.bat";
    process.StartInfo.Arguments = @"-X";
    process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
    process.StartInfo.UseShellExecute = false; //Changed Line
    process.StartInfo.RedirectStandardOutput = true;  //Changed Line
    process.Start();
    string output = process.StandardOutput.ReadToEnd(); //Changed Line
    process.WaitForExit(); //Moved Line
