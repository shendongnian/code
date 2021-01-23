    using (SqlConnection con = new SqlConnection("your connection string")) {
      string sql = "UPDATE table1 Set field1 = '" + xdoc.GetXml() + "'";
      SqlCommand com = new SqlCommand(sql, con);
      con.Open();
      com.ExecuteNonQuery();
      con.Close();
    }
