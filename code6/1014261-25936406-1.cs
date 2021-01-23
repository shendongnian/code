    private string GetMyString()
    {
        string str = string.Empty;
        for (int i = 0; i < 1000000000; i++)
        {
            // compute str using simple c# code
        }
        return str;
    }
...
    Task<string> getStringTask = Task.Run(() => GetMyString());
