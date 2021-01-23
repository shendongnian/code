    
    using Microsoft.Office.Interop.Access;
    ...
    var accApp = new Application();
    accApp.OpenCurrentDatabase(@"C:\Users\Public\Database1.accdb");
    Dao.Database cdb = accApp.CurrentDb();
    Dao.Recordset rst = 
            cdb.OpenRecordset(
                "SELECT FullName FROM ClientQuery", 
                Dao.RecordsetTypeEnum.dbOpenSnapshot);
    while (!rst.EOF)
    {
        Console.WriteLine(rst.Fields["FullName"].Value);
        rst.MoveNext();
    }
    rst.Close();
    accApp.CloseCurrentDatabase();
    accApp.Quit();
