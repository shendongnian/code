    string inputDirectory = "";
    private void DoSomething(string inputDirectory)
    {
        if (String.IsNullOrEmpty(inputDirectory)
            throw new ArgumentNullException();
        try
        {
            Directory.CreateDirectory(inputDirectory)
        }
        catch (ArgumentNullException e)
        {
            Log.Error("program failed because the directory supplied was empty", e.Message);
        }
    }
