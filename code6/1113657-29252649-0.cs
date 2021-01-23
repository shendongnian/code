    string sourceDbSpec = @"C:\Users\Public\a.accdb";
    string destinationDbSpec = @"C:\Users\Public\b.accdb";
    
    // Required COM reference for project:
    // Microsoft Office 14.0 Access Database Engine Object Library
    var dbe = new Microsoft.Office.Interop.Access.Dao.DBEngine();
    try
    {
        dbe.CompactDatabase(sourceDbSpec, destinationDbSpec);
    }
    catch (Exception e)
    {
        Console.WriteLine("Error: " + e.Message);
    }
