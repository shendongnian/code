    private const string ODBC_INI_REG_PATH = "SOFTWARE\\ODBC\\ODBC.INI\\";
    public static bool DSNExists(string dsnName)
    {
        var sourcesKey = Registry
            .LocalMachine.CreateSubKey(ODBC_INI_REG_PATH + "ODBC Data Sources");
        if (sourcesKey == null) 
            throw new Exception("ODBC Registry key for sources does not exist");
        string[] blah = sourcesKey.GetSubKeyNames();
        Console.WriteLine("length: " + blah.Length);
        var dsnKey = sourcesKey.OpenSubKey(dsnName);
        bool exists = (dsnKey != null);
        if (exists) dsnKey.Close();
        sourcesKey.Close();
        return exists;
    }
