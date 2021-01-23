    public static String ExecuteSimpleSelectQuery(string ConnectionString, string _Query, string DataTableName)
        {      
            SqlConnection conn = new SqlConnection(ConnectionString);            
            SqlCommand cmd = new SqlCommand(_Query,conn);
                string result;
            conn.Open();
            var dt = new DataTable();
            dt.Load( cmd.ExecuteReader());
           
           
            using (StringWriter sw = new StringWriter()) {
            dt.WriteXml(sw);
             result = sw.ToString();
           }
           
            conn.Close();
            return result;
        }
