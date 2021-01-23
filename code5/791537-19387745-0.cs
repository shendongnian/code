    try
    {
        dbconn.table.AddObject(newRow);
        dbconn.SaveChanges();
    }
    catch (EntityException ex)
    {
        Console.WriteLine("DB fail ID:" + Row.id + "; Error: " + ex.Message);
        var sqlExc = ex.InnerException as SqlException;
        if (sqlExc != null)
            Console.WriteLine("SQL error code: " + sqlExc.Number);
    }
