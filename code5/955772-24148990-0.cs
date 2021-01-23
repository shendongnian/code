    DBDataContext db = new DBDataContext();
    TestTable tb = new TestTable();
    tb.Name = "Some Name";
    db.TestTables.InsertOnSubmit(tb);
    Console.WriteLine(tb.ID); //returned 0
    db.SubmitChanges();
    Console.WriteLine(tb.ID); //returned 1
