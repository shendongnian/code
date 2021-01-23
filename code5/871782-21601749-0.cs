    var query1 = li.GroupBy(t => t.name[0]).Select(t => new {Letter=t.Key, Students=t.GroupBy(s => s.name)});
    foreach (var item in query1) 
    {
        Console.WriteLine(item.Letter);
        foreach (var item1 in item.Students) 
        {
            Console.WriteLine("Key:" + item1.Key);
            foreach (var item2 in item1) 
            {
                Console.WriteLine(item2.name+","+item2.marks);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
