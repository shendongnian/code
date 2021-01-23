    void Main()
    {
        string input = "test";
        string result;
        Stopwatch sw = new Stopwatch();
        sw.Start();
        for(int x = 0; x < 1000000; x++)
            result = GetString(input);
            
        sw.Stop();
        Console.WriteLine(sw.ElapsedMilliseconds);
    
        sw = new Stopwatch();
        sw.Start();
        for(int x = 0; x < 100000; x++)
            result = GetString2(input);
            
        sw.Stop();
        Console.WriteLine(sw.ElapsedMilliseconds);
    }
    
    string GetString(string input)
    {
         int pos = input.IndexOfAny(new char[] {',','(', '[', '!'});
         return (pos >= 0 ? input.Substring(0, pos) : string.Empty);
    }
    
    string GetString2(string input)
    {
        try
        {
           return input.Substring(0, input.IndexOfAny(new [] { ',', '(', '[', '!' }));
        }
        catch
        {
            return string.Empty;
        }
    }
