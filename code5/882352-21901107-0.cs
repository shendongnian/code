    try
    {
    Det details = Det();   
    SqlCommand cmd = new SqlCommand("Select ID,Name,Job,ContactNo From Mytable", con);
    SqlDataReader reader = cmd.ExecuteNonQuery();
    while(reader.Read())
    {
      details.ID=details.reader["ID"].ToString();
      details.Name=details.reader["Name"].ToString();
      details.Job=details.reader["Job"].ToString();
      details.ContactNo=details.reader["ContactNo"].ToString();
    }
   
    con.Close();
    return details;
    }
