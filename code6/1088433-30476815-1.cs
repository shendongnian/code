    public Int64 id(string fd, string tb)
    {
        Int64 I = 0;
        if (con.State == ConnectionState.Open)
        {
            con.Close();
        else
        {
            con.Open();
        }
        SqlCommand cmd = new SqlCommand("SELECT MAX (" + fd + ") FROM " + tb + "", con);
        cmd.CommandType = CommandType.Text;
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
            I = Convert.ToInt64((cmd.ExecuteScalar().Equals(DBNull.Value) ? 0 : cmd.ExecuteScalar())) + 10;
        }
        return I; 
    }
