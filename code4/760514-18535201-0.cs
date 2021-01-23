    List<dynamic> list = new List<dynamic>();
    list.Add(1);
    list.Add("ABCD");
    list.Add(1f);
    foreach (var item in list)
    {
        Console.WriteLine(item.GetType());
    }
