    public IEnumerable<string> GetEmails()
    {
      using (SqlConnection conn = new SqlConnection(""))
      {
          SqlCommand cmd = new SqlCommand("SELECT email FROM dbo.Members", conn);
          conn.Open();
          SqlDataReader rdr = cmd.ExecuteReader();
          while (rdr.Read())
          {
              toaddress = rdr["email"].ToString();
          }
          rdr.Close();
      }
    }
