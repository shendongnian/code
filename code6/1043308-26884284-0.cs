    // This code requires the following COM reference in your project:
    //
    //     Microsoft Office 14.0 Access Database Engine Object Library
    //
    // and the declaration
    //
    //     using Microsoft.Office.Interop.Access.Dao;
    //
    // at the top of the class file            
    
    var dbe = new DBEngine();
    Database db = dbe.OpenDatabase(@"C:\Users\Public\test\a97_files\a97table1 - Copy.mdb");
    Recordset rst = db.OpenRecordset("SELECT * FROM table1", RecordsetTypeEnum.dbOpenDynaset);
    rst.AddNew();
    // new AutoNumber is created as soon as AddNew() is called
    int newID = rst.Fields["ID"].Value;  
    rst.Fields["textCol"].Value = "Record added via DAO Recordset.";
    rst.Update();
    Console.WriteLine("Row added with ID = {0}", newID);
    rst.Close();
    db.Close();
