    List<int> list = new List<int>();
    Random rnd = new Random();
    for (var k = 0; k <= 5; k++)
        list.Add(rnd.Next(0, 10));
    int min = 0;
    int max = 0;
    for (var i = 0; i < list.Count; i++)
    {
        if (list[i] < min)
            min = i;
        if (list[i] > max)
            max = i;
    }
    Console.Write("Before: ");
    foreach (var item in list)
        Console.Write("{0}", item);
    var tmp = list[min];
    list[min] = list[max];
    list[max] = tmp;
    Console.Write("\nAfter: ");
    var queue = new Queue(list);
    foreach (var item in queue)
        Console.Write("{0}", item);
    Console.ReadLine();
