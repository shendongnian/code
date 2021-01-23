    Try this :
    public static void connect()
    {
        conn.Open();
        SqlCommand command = new SqlCommand("spTester", conn);
        command.CommandType = CommandType.StoredProcedure;
        command.AddWithValue("@Parameter1","this is tested")
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        conn.Close();
    }
