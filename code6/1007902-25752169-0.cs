    var accApp = new Microsoft.Office.Interop.Access.Application();
    accApp.OpenCurrentDatabase(@"C:\Users\Public\Database1.accdb");
    Microsoft.Office.Interop.Access.Dao.Database cdb = accApp.CurrentDb();
    Microsoft.Office.Interop.Access.Dao.Recordset rst = 
            cdb.OpenRecordset(
                "SELECT FullName FROM ClientQuery", 
                Microsoft.Office.Interop.Access.Dao.RecordsetTypeEnum.dbOpenSnapshot);
    while (!rst.EOF)
    {
        Console.WriteLine(rst.Fields["FullName"].Value);
        rst.MoveNext();
    }
    rst.Close();
    cdb.Close();
    accApp.Quit();
