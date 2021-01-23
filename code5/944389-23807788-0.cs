    // This code requires the following COM reference in your project:
    //
    //     Microsoft Office 14.0 Access Database Engine Object Library
    //
    // and the declaration
    //
    //     using Microsoft.Office.Interop.Access.Dao;
    //
    // at the top of the class file            
    string tableDefName = "CLOASEUCDBA_T_BASIC_POLICY";
    var dbe = new DBEngine();
    Database db = dbe.OpenDatabase(@"C:\Users\xxxx\Documents\Test.accdb");
    var tbdOld = db.TableDefs[tableDefName];
    var tbdNew = db.CreateTableDef(tableDefName);
    tbdNew.Connect = tbdOld.Connect;
    tbdNew.SourceTableName = "CLOASEUCDBA_T_BILLING_INFORMATION";
    db.TableDefs.Delete(tableDefName);  // remove the old TableDef ...
    db.TableDefs.Append(tbdNew);        // ... and append the new one
    db.Close();
