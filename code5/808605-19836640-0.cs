    var l = new List<string>();
    l.Add("A");
    l.Add("B");
    l.Add("C");
    l.Add("D");
    l.Add("E");
    l.Add("F");
    l.Add("G");
    l.Add("H");
    l.Add("I");
            
    var random = new Random();
    var nl = l.Select(i=> new {Value=i,Index = random.Next()});
            
    var finalList = nl.OrderBy(i=>i.Index).Take(3);
    foreach(var i in finalList)
    {
        Console.WriteLine(i.Value);
    }
