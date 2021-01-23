    var list = new List<int>();
    for(int i = 0; i < 10000; i++)
    {
        list.Add(i);
    }
    Console.WriteLine(list.Capacity); // 16384
    list.Clear();
    Console.WriteLine(list.Capacity); // 16384
