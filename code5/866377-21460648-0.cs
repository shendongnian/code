     var proc = new Process
     {
        EnableRaisingEvents = false,
        StartInfo =
           {
               UseShellExecute = false,
               FileName = path,
               Arguments = @argument
           }
      };
      proc.Start();
