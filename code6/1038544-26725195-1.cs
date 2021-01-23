    var dic = new Dictionary<string, int>();
    Console.WriteLine("enterv");
    var v = Console.ReadLine();
    Console.WriteLine("enter k");
    var k = int.Parse(Console.ReadLine());
    dic.Add(v, k);
    var minKey = dic.Keys.First();
    var minValue = dic[minKey];
    foreach (var item in dic)
    {
        if (item.Value < minValue)
        {
            minValue = item.Value;
            minKey = item.Key;
        }
    }
    Console.WriteLine(string.Format("{0}, {1}" ,minKey, miniValue));
