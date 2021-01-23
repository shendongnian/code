      DateTime start = new DateTime(2000, 2, 25);
      DateTime end = new DateTime(2000, 3, 2);
      String sql = "";
      for (int i = 0; i < end.Subtract(start).Days; i++)
      {
          if (sql.Length > 0)
              sql += ",";
          sql += "\n('" + start.AddDays(i).ToString("yyyy-MM-dd") + "')";
      }
      sql = "INSERT INTO tableX VALUES" + sql;
