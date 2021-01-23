            SqlCommand sqlComm = new SqlCommand("spselect", conn);               
            sqlComm.Parameters.AddWithValue("@parameter1", parameter1value);
            sqlComm.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlComm;
            da.Fill(ds);
     }
