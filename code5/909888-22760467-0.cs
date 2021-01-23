    public static Task TestExAsync(string filename)
    {
        if (!System.IO.File.Exists(filename))
            throw new System.IO.FileNotFoundException(filename);
    
        return TestExAsyncImpl(filename);
    }
    
    private static Task TestExAsyncImpl(string filename)
    {
        await Task.Delay(1000);
    }
