    var smiths = new List<Persons>();
    // get all Smiths and print them
    foreach(var item in newlist)
    {
        if(item.last == "smith")
            smiths.Add(item);
    }
    
    foreach(var item in smiths)
    {
        Console.WriteLine(item);
    }
