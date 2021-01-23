    using (var context = new FooContext())
    {
        context.Database.Log = s => Console.WriteLine(s);
        var query = context.Foos.FirstOrDefault(x => x.Id == 1).Bar.Value;
    }
