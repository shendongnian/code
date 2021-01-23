    string SQL2 = "SELECT ins.int_id, ins.FK_is_ID, ine.FK_ie_ID" +
    " FROM " +
    "   Interests ins" + // For Seekers
    "   INNER JOIN Interests ine" + //  For Employers
    "   ON ins.FK_ic_ID = ine.FK_ic_ID " +
    " WHERE " +
    "   ins.FK_is_ID = @sid " +
    "   AND ine.FK_ie_ID IS NOT null ";
    
    using var (myCommand2 = new SqlCommand(SQL2, myConn2))
    {
      myCommand2.CommandType = CommandType.Text;
      myCommand2.Parameters.AddWithValue("@sid", ssid);
      using (myReader2 = myCommand2.ExecuteReader())
      {
        var sb = new StringBuilder;
        while (myReader2.Read())
        {
           divjobs = string.Format("<li>{0}</a></li>", (string)myReader2["FK_ie_ID"]);
        }
        divjobs = sb.ToString();
      }
    } 
