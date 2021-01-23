    string programPath = System.IO.Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).FullName;
    var dbPath = System.IO.Directory.GetFiles(programPath, "*.accdb", SearchOption.AllDirectories).FirstOrDefault();
    string cs = null;
    if (!string.IsNullOrEmpty(dbPath))
    {
    	cs = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Persist Security Info=False;", dbPath);
    }
