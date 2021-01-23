    // required COM reference: Microsoft Office 14.0 Access Database Engine Object Library
    //
    // using Microsoft.Office.Interop.Access.Dao; ...
    var dbe = new DBEngine();
    Database db = dbe.OpenDatabase(@"C:\Users\Public\Database1.accdb");
    TableDef tbd = db.TableDefs["Foo"];
    string oldConnect = tbd.Connect;
    char[] delimiter = { ';' };
    string[] connectParams = oldConnect.Split(delimiter);
    for (int i = 0; i < connectParams.Length; i++)
    {
        if (connectParams[i].StartsWith("DATABASE=", StringComparison.InvariantCultureIgnoreCase))
        {
            connectParams[i] = @"DATABASE=C:\Users\Public";
            break;
        }
    }
    string newConnect = String.Join(Convert.ToString(delimiter[0]), connectParams);
    tbd.Connect = newConnect;
    tbd.RefreshLink();
    db.Close()
