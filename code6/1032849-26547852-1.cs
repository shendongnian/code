    OleDbConnection conn = new OleDbConnection();
    
    
    string connectString = String.Format(
                        "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0 Xml;HDR={1};'",
                        fileName, "YES");
    
                    conn.ConnectionString = connectString;
                    conn.Open();
    
     OleDbCommand comm = new OleDbCommand();
     comm.CommandText = string.Format("CREATE TABLE [{0}] ", "TableName");
