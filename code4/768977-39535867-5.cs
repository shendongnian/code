    public FileContentResults DownloadCSV()
    {
      // I have a stored procedure that queries the information I need
      SqlConnection thisConnection = new SqlConnection("Data Source=sv12sql;User ID=UI_Readonly;Password=SuperSecure;Initial Catalog=DB_Name;Integrated Security=false");
      SqlCommand queryCommand = new SqlCommand("spc_GetInfoINeed", thisConnection);
      queryCommand.CommandType = CommandType.StoredProcedure;
      StringBuilder sbRtn = new StringBuilder();
      // If you want headers for your file
      var header = string.Format("\"{0}\",\"{1}\",\"{2}\"",
                                 "Name",
                                 "Address",
                                 "Phone Number"
                                );
      sbRtn.AppendLine(header);
      // Open Database Connection
      thisConnection.Open();
      using (SqlDataReader rdr = queryCommand.ExecuteReader())
      {
        while (rdr.Read())
        {
          // rdr["COLUMN NAME"].ToString();
          var queryResults = string.Format("\"{0}\",\"{1}\",\"{2}\"",
                                            rdr["Name"].ToString(),
                                            rdr["Address"}.ToString(),
                                            rdr["Phone Number"].ToString()
                                           );
          sbRtn.AppendLine(queryResults);
        }
      }
      thisConnection.Close();
      return File(new System.Text.UTF8Encoding().GetBytes(sbRtn.ToString()), "text/csv", "FileName");
    }
