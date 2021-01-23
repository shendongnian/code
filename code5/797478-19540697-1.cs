    static int? ReadInteger()
    {
        int result;
        if (!int.TryParse(Console.ReadLine(), out result))
        {
            return null;
        }
        return result;
    }
    static void Main(string[] args)   
    {
        int?[] ar = new int?[10002];
        int? n = ReadInteger();
        if (!n.HasValue)
        {
            Console.WriteLine("Please input a correct integer");
            return;
        }
        for( int i = 0;i < n.Value; i++ )
        {
            ar[i] = ReadInteger();
        }
        for ( int i = 0; i < n.Value; i++ )
        {
            Console.WriteLine(ar[i].HasValue
                ? ar[i].Value.ToString() : "Incorrect input");
        }
        Console.ReadKey();
    }
