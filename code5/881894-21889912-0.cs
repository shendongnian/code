    Stream inputFile = null;
    try
    {
      inputFile = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
      DoSomeActionThatMayReturnNewStream(ref inputFile);
      DoSomeMoreStuffWithStream(inputFile);
    }
    finally
    {
      if (inputFile != null)
        inputFile.Dispose();
    }
