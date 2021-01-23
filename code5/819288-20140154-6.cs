    Microsoft.Office.Interop.Access.Dao.Database cdb = objAccess.CurrentDb();
    foreach (Microsoft.Office.Interop.Access.Dao.Relation rel in cdb.Relations)
    {
        Console.WriteLine(rel.Name);
    }
