     var startInfo = new System.Diagnostics.ProcessStartInfo
     {
         WorkingDirectory = projectRoot,
         FileName = projectRoot + @"\undoUnchanged.bat",
         UseShellExecute = false,
         CreateNoWindow = true
     };
     Process process = Process.Start(startInfo);
     process.WaitForExit();
     process.Close();
