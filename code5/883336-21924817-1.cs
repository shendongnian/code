    public DataSet GetData()
    {
        DataSet ds;
        using (OleDbConnection conn = new OleDbConnection(connString))
        {
            string query= "select * from tblTest where location = ?";            
            using (OleDbCommand myCommand = new OleDbCommand(query, conn))
            {
             
                myCommand.Parameters.AddWithValue("@ddlStates", <your value>);
                conn.Open();
                using (OleDbDataAdapter da = new OleDbDataAdapter(myCommand, conn))
                {
                    ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
            
        }
    }
