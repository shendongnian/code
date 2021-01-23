    // test data
    string tableName = "Members";
    string oldFieldName = "Photo";
    string newFieldName = "Photograph";
    // COM Reference required in C# project:
    //     Microsoft Office 14.0 Access Database Engine Object Library
    //
    var dbe = new Microsoft.Office.Interop.Access.Dao.DBEngine();
    Microsoft.Office.Interop.Access.Dao.Database db = dbe.OpenDatabase(@"C:\Users\Public\accdbTest.accdb");
    Microsoft.Office.Interop.Access.Dao.Field fld = db.TableDefs[tableName].Fields[oldFieldName];
    fld.Name = newFieldName;
    db.Close();
