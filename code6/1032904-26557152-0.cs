    // Generic
    var genericList = new GenericList<SpecialItem>();
    foreach (var item in genericList)
    {
        Console.WriteLine(item.Title);
    }
    
    var l = genericList.ToList();
    
    // Nongeneric
    var nongenericList = genericList as NongenericBaseList;
    foreach (var item in nongenericList)
    {
        Console.WriteLine(item.Name);
    }
    
    var nl = nongenericList.ToList();
