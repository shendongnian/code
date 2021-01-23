    List<int> list = new List<int>(){1, 2, 3, 4, 5};
    if(!list.Contains(6))
        list.Add(6);
    foreach (var i in list)
    {
       Console.WriteLine(i);
    }
