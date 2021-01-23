    int size = 100000;
    
    var list = new List<Item>(size); // <- setting capacity
    
    for (int i = 0; i < size; ++i)
      list.Add(new Item() { ID = i, Title = "Item" });
