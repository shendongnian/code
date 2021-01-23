    SqlCommand cmd = new SqlCommand(sqlquery, con);
    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow);
    if (reader.HasRows)
    {
    while (reader.Read())
    {
    ct = new ctyp();
    ct.ID = Convert.ToInt32(reader["MyID"]);
    ct.Name = Convert.ToString(reader["Name"]);
    }
    }
