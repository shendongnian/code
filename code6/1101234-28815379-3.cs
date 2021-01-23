    var list = new List<int>();
    for (var i = 0; i < 3000; i++)
        list.Add(i);
    
    DateTime t0 = DateTime.Now;
    for(int i = 0; i < 50000; i++) {
        Method1(list);
    }
    DateTime t1 = DateTime.Now;
    for(int i = 0; i < 50000; i++) {
        Method2(list);
    }
    DateTime t2 = DateTime.Now;
    Console.WriteLine(t1-t0);
    Console.WriteLine(t2-t1);
