    List<Test> listT;
    using (Model1 db = new Model1())
    {
        listT = db.Tests.ToList(); //ToList Evaluates
    }
    foreach (var a in listT)
    {
        Console.WriteLine(a.value);
    }
    IEnumerable<Test> listT1;
    using (Model1 db = new Model1())
    {
        listT1 = db.Tests;
    }
    foreach (var a in listT1) //foreach evaluates (but at wrong time)
    {
        Console.WriteLine(a.value);
    }
