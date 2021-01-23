    try
    {
    Det details = Det();   
    SqlCommand cmd = new SqlCommand("Select ID,Name,Job,ContactNo From Mytable", con);
    SqlDataReader reader = cmd.ExecuteNonQuery();
    while(reader.Read())
    {
      details.ID=reader["ID"].ToString();
      details.Name=reader["Name"].ToString();
      details.Job=reader["Job"].ToString();
      details.ContactNo=reader["ContactNo"].ToString();
    }
   
    con.Close();
    return details;
    }
