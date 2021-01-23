    private string GPGEncrypt(string src)
    {
      FileInfo fi = new FileInfo(src);
      string OutputName = GetEncryptedName(src);
      if (File.Exists(OutputName))
      {
        if (!chkOverwrite.Checked)
        {
          SetStatus("Output file already exists - " + OutputName);
          return "";
        }
      }
    
      string path = fi.DirectoryName;
    
      System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo(props.PGPExecutable);
      psi.CreateNoWindow = true;
      psi.UseShellExecute = false;
      psi.RedirectStandardError = true;
      psi.RedirectStandardInput = true;
      psi.RedirectStandardOutput = true;
      psi.WorkingDirectory = Path.GetDirectoryName(props.PGPExecutable);
    
      string args = string.Format(
        " --encrypt --recipient {0} --output \"{1}\" \"{2}\""
        , txtEncryptID.Text.Trim() // 1
        , OutputName // 2
        , src // 3
      );
    
      txtCommandLine.Text = args;
    
      psi.Arguments = args;
    
      System.Diagnostics.Process process = System.Diagnostics.Process.Start(psi);
      // process.StandardInput.WriteLine(CommandLine);
      // process.StandardInput.Flush();
      // process.StandardInput.Close();
      process.WaitForExit();
      int rc = process.ExitCode;
      process.Close();
    
      txtCommandLine.Text = string.Format("{0} exited with return code {1},", Path.GetFileName(props.PGPExecutable), rc);
    
      return OutputName;
    }
