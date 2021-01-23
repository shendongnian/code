    List<string> list = new List<string>();
    list.Add("A");
    list.Add("B");
    list.Add("C");
    list.Add("D");
    list.Add("A");
    list.Add("B");
    list = list.Select(x => x.Replace("A","C")).ToList();
