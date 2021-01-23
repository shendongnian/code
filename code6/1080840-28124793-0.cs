    string cmdString="INSERT INTO BillsDetails('BillID','CallDialledID','CallDateTime','CallDuration','CallNetPrice','CallRetailPrice','CallDiscountPrice') VALUES (@val1, @va2, @val3,@val4, @va5, @val6,@val7)";
    string connString = "your connection string";
    using (SqlConnection conn = new SqlConnection(connString))
    {
        using (SqlCommand comm = new SqlCommand())
        {
            comm.Connection = conn;
            comm.CommandString = cmdString;
            comm.Parameters.AddWithValue("@val1", 'your value');
            comm.Parameters.AddWithValue("@val2", 'your value');
            comm.Parameters.AddWithValue("@val3", 'your value');
            comm.Parameters.AddWithValue("@val4", 'your value');
            comm.Parameters.AddWithValue("@val5", 'your value');
            comm.Parameters.AddWithValue("@val6", 'your value');
            comm.Parameters.AddWithValue("@val7", 'your value');
            try
            {
                conn.Open();
                comm.ExecuteNonQuery();
                conn.Close();
            }
            Catch(SqlException e)
            {
               
            }
        }
    }
