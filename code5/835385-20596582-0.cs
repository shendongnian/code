    public DataTable fillDataTable()
    {
        // select all the columns with expected column name, here I only added 3 columns 
        string query = "SELECT username as Username, motto as Motto, mail as Email FROM users;
    
        using(SqlConnection sqlConn = new SqlConnection(conSTR))
        using(SqlCommand cmd = new SqlCommand(query, sqlConn))
        {
            sqlConn.Open();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            return dt;
        }
    }
