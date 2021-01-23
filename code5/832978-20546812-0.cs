    static int Main(string[] args)
    {
        try
        {
            var x = 0;
            var y = 1 / x;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex);
            return 1;
        }
                
        return 0;
    }
