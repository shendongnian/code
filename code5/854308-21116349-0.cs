    public DataTable GetRecords(DateTime dtParameter)
    {
        DataTable dt = null;
        using (SqlConnection conn = new SqlConnection("connection string"))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT * from yourTable where DateField = @dateparameter"))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@dateparameter",dtParameter);
                SqlDataReader dr = cmd.ExecuteReader();
                //...rest of the code
                dt.Load(dr);
            }
        }
        return dt;
    }
