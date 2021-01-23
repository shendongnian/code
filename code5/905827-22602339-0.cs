    public static void connect()
    {
        conn.Open();
        SqlCommand command = new SqlCommand("spTester 'this is tested'", conn);
        command.CommandType = CommandType.StoredProcedure;
       SqlDataAdapter da = new SqlDataAdapter(cmd);
        conn.Close();
    }
