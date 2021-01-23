    if (reader.HasRows)
    {
        reader.Read();
        lblEvent1.Text = reader["EVENTNAME"].ToString();
    }
    if (reader.HasRows)
    {
        reader.Read();
        lblEvent2.Text = reader["EVENTNAME"].ToString();
    }
    if (reader.HasRows)
    {
        reader.Read();
        lblEvent3.Text = reader["EVENTNAME"].ToString();
    }
