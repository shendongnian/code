    static void Main(string[] args)
    {
        EventTest e = new EventTest(5);
        e.ChangeNum += () => Console.WriteLine("Num changed"); //<== this
        e.SetValue(7);
        e.SetValue(11);
        Console.ReadKey();
    }
