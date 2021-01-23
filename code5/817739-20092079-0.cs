        public static DataTable ExecuteQuery(string query, string table)
        {
            DataSet Ds = new DataSet();
            SqlConnection cnn = new SqlConnection(ConnectionInfo);
 
            try{
                SqlDataAdapter Adp = new SqlDataAdapter(query, cnn);
                Adp.Fill(Ds, table);
                return Ds.Tables[table]; 
            }
            catch{
                throw;
            }
            finally{
                cnn.Close();
            }
                      
        }
