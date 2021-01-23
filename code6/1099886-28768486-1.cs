    public void CalculateFRDBToks(TestBLL testToks)
    {
        try
        {
            using (SqlConnection con = new SqlConnection("Connection String"))
            using (SqlCommand cmd = new SqlCommand("SELECT col1, col2, col3 FROM TOKS_TEST", con))
            {
                con.Open();
                cmd.CommandType = CommandType.Text;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine("Col1 {0}, Col2 {1}, Col3 {2}", dr["Col1"], dr["Col2"], dr["Col3"]);
                    //or populate a List of your object based on values
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
