    static int starter(int n)
    {
        var x = n % 10;
        return n - x + 1;
    }
    static void Main(string[] args)
    {
        Console.WriteLine(starter(24));
        Console.ReadLine();
    }
