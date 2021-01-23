    var foo = GetTable("").AsEnumerable()
                     .ToLookup(x => x.Key, x => x.Value);
    foreach(var x in foo)
    {
        foreach(var value in x)
        {
            Console.WriteLine(string.Format("{0} {1}", x.Key, value));
        }
    }
