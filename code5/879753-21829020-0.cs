    testItems.ToList().ForEach(item=>
    {
     if (!testMap.ContainsKey(item.GetId()))
     {
       testMap.Add(item.GetId(), item);
     }
    });
