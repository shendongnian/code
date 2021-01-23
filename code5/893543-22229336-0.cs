    public static async Task Foo()
    {
        try
        {
            await Task.Run(() => DoSomething());
            await Task.Run(() => DoSomethingElse());
        }
        catch(Exception e)
        {
            Console.WriteLine(e);
        }
    }
