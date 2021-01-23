    public class myDataSet : DataSet
    {
    
        OleDbConnection conn;
        OleDbDataAdapter DBDA;
        OleDbCommand SqlCmd;
        string ConnectionString = @"your default connection string here!";
    
        public myDataSet (string connectString)
        {
            conn = new OleDbConnection();
    
            if (String.IsNullOrEmpty(connectString)) 
                    conn.ConnectionString = ConnectionString;
            else conn.ConnectionString = connectString;
    
            connectMe();
    
            DataTable userTables = conn.GetSchema("Tables");
    
            SqlCmd = new OleDbCommand("select * from [Names]", conn);
            DBDA = new OleDbDataAdapter(SqlCmd);
            DataTable Names = new DataTable("Names");
            DBDA.Fill(Names); 
            SqlCmd = new OleDbCommand("select * from [Places]", conn);
            DBDA = new OleDbDataAdapter(SqlCmd);
            DataTable Places= new DataTable("Places");
            DBDA.Fill(Places);
    
            conn.Close();
    
            this.Tables.Add(userTables);
            this.Tables.Add(Names);
            this.Tables.Add(Places);
    
        }
    
        public bool connectMe()
        {
            try { conn.Open();  } 
            catch { /* your error hanfdilng here! */}
            if (conn.State == ConnectionState.Open) return true;
            return false;
        }
    
    }
