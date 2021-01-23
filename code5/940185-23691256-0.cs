    if FileExists(localFilename) {
        if !System.Diagnostics.Process.Start(localFilename) 
        {
          // Handle failure to start process
        };
    }
    else
    {
      // Handle missing file
    }
