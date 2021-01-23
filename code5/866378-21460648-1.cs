     var proc = new Process
     {
        EnableRaisingEvents = false,
        StartInfo = new ProcessStartInfo()
           {
               UseShellExecute = false,
               FileName = path,
               Arguments = Request.QueryString["DKT_ID"].ToString()
           }
      };
      proc.Start();
