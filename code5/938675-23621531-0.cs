    public async Task<Task<string>[]> DoIt()
    {
        var urls = new string[] { "http://www.msn.com", "http://www.google.com" };
        var tasks = urls.Select(x => this.GetUrlContents(x)).ToArray();
        await Task.WhenAll(tasks);
        return tasks;
    }
// ...
    static void Main(string[] args)
    {
        var lib = new AsyncLib();
        foreach(var item in await lib.DoIt())
        {
            Console.WriteLine(item.Result.Length);
        }
        Console.Read();
    }
