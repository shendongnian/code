    public static async Task Method() {
        int a=3;
        Console.WriteLine(a);
        {
            int b=3;
            Console.WriteLine(b);
        }
        await Task.FromResult(true);
    }
