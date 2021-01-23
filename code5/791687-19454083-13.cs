    private constr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=yourdbfile.mdb;Jet OLEDB:Database Password=yourpassword;";
    
    OleDbConnection conn = new OleDbConnection(constr);
    
    string query = "SELECT * FROM [YourTable]";
    
    OleDbCommand cmd = new OleDbCommand(query, conn);
    
    DataTable t1 = new DataTable();
    using (OleDbDataAdapter a = new OleDbDataAdapter(cmd))
    {
        a.Fill(t1);
    }
