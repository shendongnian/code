    public async void Run(string path)
    {
        IAsyncEnumerable<string> lines = TestAsync(new StreamReader(path));
        await foreach (var line in lines)
        {
            Console.WriteLine(line);
        }
    }
    private async IAsyncEnumerable<string> TestAsync(StreamReader sr)
    {
        while (true)
        {
            string line = await sr.ReadLineAsync();
            if (line == null)
                break;
            yield return line;
        }
    }
 
