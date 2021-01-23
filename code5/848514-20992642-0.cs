    [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes",
      Justification = "Many exceptions possible, all of them survivable.")]
    [ExcludeFromCodeCoverage]
    private static bool AttemptDetectAllowUnalignedRead()
    {
      switch(Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE"))
      {
        case "x86":
        case "AMD64": // Known to tolerate unaligned-reads well.
          return true;
      }
      // Analysis disable EmptyGeneralCatchClause
      try
      {
        return FindAlignSafetyFromUname();
      }
      catch
      {
        return false;
      }
    }
    [SecuritySafeCritical]
    [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes",
      Justification = "Many exceptions possible, all of them survivable.")]
    [ExcludeFromCodeCoverage]
    private static bool FindAlignSafetyFromUname()
    {
      var startInfo = new ProcessStartInfo("uname", "-p");
      startInfo.CreateNoWindow = true;
      startInfo.ErrorDialog = false;
      startInfo.LoadUserProfile = false;
      startInfo.RedirectStandardOutput = true;
      startInfo.UseShellExecute = false;
      try
      {
        var proc = new Process();
        proc.StartInfo = startInfo;
        proc.Start();
        using(var output = proc.StandardOutput)
        {
          string line = output.ReadLine();
          if(line != null)
          {
            string trimmed = line.Trim();
            if(trimmed.Length != 0)
              switch(trimmed)
              {
                case "amd64":
                case "i386":
                case "x86_64":
                case "x64":
                  return true; // Known to tolerate unaligned-reads well.
              }
          }
        }
      }
      catch
      {
        // We don't care why we failed, as there are many possible reasons, and they all amount
        // to our not having an answer. Just eat the exception.
      }
      startInfo.Arguments = "-m";
      try
      {
        var proc = new Process();
        proc.StartInfo = startInfo;
        proc.Start();
        using(var output = proc.StandardOutput)
        {
          string line = output.ReadLine();
          if(line != null)
          {
            string trimmed = line.Trim();
            if(trimmed.Length != 0)
              switch(trimmed)
            {
              case "amd64":
              case "i386":
              case "i686":
              case "i686-64":
              case "i86pc":
              case "x86_64":
              case "x64":
                return true; // Known to tolerate unaligned-reads well.
              default:
                if(trimmed.Contains("i686") || trimmed.Contains("i386"))
                  return true;
                return false;
            }
          }
        }
      }
      catch
      {
        // Again, just eat the exception.
      }
      // Analysis restore EmptyGeneralCatchClause
      return false;
    }
