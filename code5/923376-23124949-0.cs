    var list = new List<String>();
    list.Add("A");
    list.Add("B");
    list.Add("C");
    
    String first = list.First();
    String last = list.Last();
    List<String> middle_elements = list.Skip(1).Take(list.Count - 2).ToList();
