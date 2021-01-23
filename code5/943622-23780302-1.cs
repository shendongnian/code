    // This code requires the following COM reference in your project:
    //     Microsoft Office 14.0 Access Database Engine Object Library
    //
    var dbe = new DBEngine();
    Database db = dbe.OpenDatabase(@"C:\Users\Public\FrontEnd.accdb");
    foreach (TableDef tbd in db.TableDefs)
    {
        if (tbd.Connect.Length > 10)
        {
            if (tbd.Connect.Substring(0, 10).Equals(";DATABASE="))
            {
                tbd.Connect = tbd.Connect.Replace("oldBackEnd.accdb", "newBackEnd.accdb");
                tbd.RefreshLink();
            }
        }
    }
    db.Close();
