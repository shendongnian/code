    var context = new YourDbContext();
    var results = context.SomeTables.Where(x=>x.SOMEATTR == "Yellow").ToList();
    //then you can iterate all results
    foreach(var item in results)
    {
        Console.WriteLine(item.ID + " " + item.NAME + " " + item.SOMEATTR);
    }
