    var list1 = new List<TypeA>();
    list1.Add(E.E1);
    list1.Add(E.E2);
    list1.Add(E.E2);
    list1.Add(E.E1);
    var count = list1 .Distinct().Count();
    Console.WriteLine(count);
