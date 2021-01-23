    public bool TryReadFile(String path, out String contentsOfFile)
    {
      try
      {
        // Try reading file
        contentsOfFile = File.ReadAllText(path);
        // Success! Yay!
        return true;
      }
      catch (IOException)
      {
        // Oops! Can't read that file!
        // Return some default and let caller know we failed
        contentsOfFile = String.Empty;
        return false;
      }
