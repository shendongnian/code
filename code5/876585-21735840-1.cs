    static void Main(string[] args)
    {
        DBEntity e = new DBEntity();
        e.Update<string>(x => x.Prop2, "test");
        Console.WriteLine(e.Prop2);
    }
