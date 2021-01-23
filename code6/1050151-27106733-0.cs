    static void Main(string[] args)
    {
        try
        {
            var task = SomeMethod1();
        }
        catch
        {
            // Unreachable code
        }
    }
    public static async Task SomeMethod1()
    {
        throw new Exception();
    }
