    var dic = new Dictionary<string, int>();
    Console.WriteLine("enterv");
    var v = Console.ReadLine();
    Console.WriteLine("enter k");
    var k = int.Parse(Console.ReadLine());
    dic.Add(v, k);
    var minimumKey = dic.Keys.First();
    var minimumValue = dic[minimumKey];
    foreach (var item in dic)
    {
        if (item.Value < minimumValue)
        {
            minimumValue = item.Value;
            minimumKey = item.Key;
        }
    }
    Console.WriteLine(string.Format("{0}, {1}" ,minimumKey, minimumValue));
