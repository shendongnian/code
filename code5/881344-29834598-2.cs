    IEnumerable<Test> listT1;
    Model1 db = new Model1();
    listT1 = db.Tests;
    foreach (var a in listT1) //foreach evaluates (but at wrong time)
    {
        Console.WriteLine(a.value);
    }
