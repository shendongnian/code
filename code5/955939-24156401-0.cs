    if (Conn.State == ConnectionState.Closed) {
        Conn.Open();
    } else if (Conn.State == ConnectionState.Open) {
        cmd = new SqlCommand("insert into [AppLog] values('" + strbuff + "', '" + time + "','" + Processing + "','" + userName + "')", Conn);
        cmd.ExecuteNonQuery();
        Conn.Close();
    }
