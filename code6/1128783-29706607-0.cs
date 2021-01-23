    StringBuilder el = new StringBuilder();
    using (SqlConnection conn = new SqlConnection(connString)) {
      SqlCommand cmd = new SqlCommand(@"
                  select * from Event 
                  WHERE DATEDIFF(d, getdate(), StartDate) BETWEEN 0 and 6
                  order by StartDate", conn);
      conn.Open();
      SqlDataReader rdr = cmd.ExecuteReader();
      if (rdr.HasRows) {
        rdr.Read();
        System.DayOfWeek lastDayProcessed = (DateTime)rdr["StartDate"]).DayOfWeek;
        el.AppendLine("<strong>" + lastDayProcessed + "</strong> -");
        el.Append(" " + rdr["Title"].ToString());
        while (rdr.Read()) {
          if (((DateTime)rdr["StartDate"]).DayOfWeek != lastDayProcessed) {
            // print the Day heading whenever the day changes
            el.AppendLine("<br />");
            lastDayProcessed = ((DateTime)rdr["StartDate"]).DayOfWeek;
            el.AppendLine("<strong>" + lastDayProcessed + "</strong> -");
          }
          el.Append(" " + rdr["Title"].ToString());
        }
      }
      rdr.Close();
    }
