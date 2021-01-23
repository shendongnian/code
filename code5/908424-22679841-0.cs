    strSQL = @"SELECT TOP 1 ContactEmail FROM vwApprenticeshipContactDetails WHERE ApprenticeshipID = @ApprenticeshipID";
    SqlCommand cmd2 = new SqlCommand(strSQL, cnn);
    cmd2.Parameters.Add("@ApprenticeshipID", SqlDbType.Int).Value = wsAppID;
    using (SqlDataReader rdr = cmd2.ExecuteReader())
    {
      string fldEmail = "support@domain.com.au";   //this is as a default in case the sql above does not return a value
      while (rdr.Read())
      {
        fldEmail = rdr.GetSqlValue(0).ToString();
      }
    }
