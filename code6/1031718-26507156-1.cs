        DataTable DT = new DataTable();
        using (SqlConnection conn = new SqlConnection(connections.supplierInfo()))
        {
            string sql = " SELECT * FROM UnionSuppliers WHERE SIM_NUMBER LIKE @parameter ";
            conn.Open();
            using (SqlCommand select = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandTimeout = 300,
                CommandText = sql,
                Connection = conn
            })
            {                    
                select.Parameters.AddWithValue("@parameter", number);
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataSet ds = new DataSet();
                adapter.SelectCommand = select;
                adapter.Fill(ds);
                DT = ds.Tables[0];
            }
        }
