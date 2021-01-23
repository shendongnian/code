      static public string RunAndGetOutput( string filename, string arguments )
      {
         // Start the child process.
         Process p = new Process();
         // Redirect the output stream of the child process.
         p.StartInfo.UseShellExecute = false;
         p.StartInfo.RedirectStandardOutput = true;
         p.StartInfo.FileName = filename;
         p.StartInfo.Arguments = arguments;
         p.Start();
         // Read the output stream first and then wait.
         string output = p.StandardOutput.ReadToEnd();
         p.WaitForExit();
         // p.ExitCode - could read this to get the exit code
         return output;
      }
