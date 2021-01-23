        ProcessStartInfo proc = new ProcessStartInfo();
    
      proc.UserName = "usernamer";
    proc.Domain = "dm";
    proc.Password = securePasswordString;
    proc.LoadUserProfile = false;
                
        proc.UseShellExecute = true;
        proc.WorkingDirectory = Environment.CurrentDirectory;
        proc.FileName = Application.ExecutablePath;
        proc.Verb = "runas";
        
                try
                {
                    Process.Start(proc);
                }
                catch
        
                {
                    // The user refused the elevation.
                    // Do nothing and return directly ...
                    return;
                }
        
                Application.Exit();  // Quit itself
