    var item = students.Where(x => x.Name == keyname).Select(x=>x.Mark).FirstOrDefault();
    Console.WriteLine(item);
    //or
    var item = students.Where(x => x.Name == keyname).FirstOrDefault();
    if (item != null)
        Console.WriteLine(item.Mark);
    //or
    var item = students.FirstOrDefault(s=> s.Name == keyname);
    if (item != null)
        Console.WriteLine(item.Mark);
