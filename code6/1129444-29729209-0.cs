    public static DataTable GetCustomer(collection b)
    {
        {
            DataTable table = new DataTable();
            try
            {
                string returnValue = string.Empty;
                DB = Connect();
                DBCommand = connection.Procedure("getCustomer");
                DB.AddInParameter(DBCommand, "@CustomerRef", DbType.String, b.CustomerRef1);
    
                SqlDataAdapter adptr = new SqlDataAdapter(DBCommand);
                adptr.Fill(table);
                return table;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
