     public static DataRowCollection getAllUsers(string tableName) {
    
    
            DataSet set = new DataSet();
    
            SqlCommand comm = new SqlCommand();
    
            comm.Connection = DAL.DAL.conn;
    
            comm.CommandType = CommandType.StoredProcedure;
    
            comm.CommandText = "getAllUsers";
           
            SqlDataAdapter da = new SqlDataAdapter();
    
            da.SelectCommand = comm;
    
            da.Fill(set,tableName);
    
            DataRowCollection usersCollection = set.Tables[tableName].Rows;
    
            return usersCollection;
    
           }
