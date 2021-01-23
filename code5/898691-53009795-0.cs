      try
      {
        Process process = new Process();
        process.StartInfo.FileName = @"C:\sqlplus.exe";
        process.StartInfo.Arguments = "user/password";
        process.StartInfo.RedirectStandardInput = true;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.RedirectStandardError = true;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.CreateNoWindow = false;
        process.StartInfo.CreateNoWindow = false;
        process.Start();
        process.StandardInput.WriteLine("@C:\\file.sql");
        process.Close();
      }
      catch (Exception ex)
      {
        throw;
      }
    } 
