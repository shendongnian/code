    DataTable table = new DataTable("Logins");
      table.Columns.Add("id", typeof(int));
      table.Columns.Add("userId", typeof(int));
      table.Columns.Add("loginDateTime", typeof(DateTime));
      table.Rows.Add(1, 233, new DateTime(2015, 01, 01, 1, 04, 22));
      table.Rows.Add(2, 233, new DateTime(2015, 01, 01, 2, 01, 43));
      table.Rows.Add(3, 234, new DateTime(2015, 01, 01, 1, 04, 12));
      table.Rows.Add(4, 235, new DateTime(2015, 01, 01, 8, 22, 54));
      IEnumerable<DataRow> linkQuery = from times 
                                       in table.AsEnumerable() 
                                       select times;
      List<DataRow> listOfTimes = new List<DataRow>();
      DateTime checkAgainst = linkQuery.ElementAt(1).Field<DateTime>("loginDateTime");
      foreach (DataRow row in linkQuery) 
      {
        TimeSpan span = new TimeSpan();
        DateTime checkedRow = row.Field<DateTime>("loginDateTime");
        span = checkAgainst - checkedRow;
        if (span.Hours == 0 && span.Minutes <= 59)
        {
          listOfTimes.Add(row);
        }
      }
      Console.ReadKey();
