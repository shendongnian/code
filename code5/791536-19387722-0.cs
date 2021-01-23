    try
    {
        dbconn.table.AddObject(newRow);
        dbconn.SaveChanges();
    }
    catch (Exception ex)
    {
        Console.WriteLine("DB fail ID:" + Row.id);
        Console.WriteLine(ex.ToString());
    }
