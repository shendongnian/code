    var list = new ArrayList();
    list.Add(3);
    list[0].ToString(); // Works fine
    
    var list = new List<string>();
    list.Add(3); // Fails
