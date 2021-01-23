    using (OleDbConnection connection = new OleDbConnection(DbConnString))
    using (DataRepositoryDataContext ctx = new DataRepositoryDataContext(connection))
    {
        var books = ctx.Daybook.Where(o=>
          o.EntryDate <= dateTimePicker13.Value &&
          o.EntryDate >= dateTimePicker12.Value &&
          o.Credit != 0 &&
          o.Debit != 0
        );
        //do something with books ex: print list of names to console
        Console.WriteLine(string.Join(",",books.Select(o=>o.Name).ToList()));
    }
