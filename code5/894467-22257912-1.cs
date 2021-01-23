    void Main()
    {
        var Foo = Enumerable.Range(0,50).Select(i => new { id = i, Bar = i%3}).ToList();
        var myList= Foo.GroupBy(a => a.Bar).Select(g => g.Key).OrderBy(a => a).ToList();
        Console.WriteLine(myList);
    }
    
