    private string (DataTable dt)
    {
    string rw = "";
    StringBuilder builder = new StringBuilder();
    foreach(DataRow dr in dt.Rows)
    {
      foreach(DataColumn dc in dr.Columns)
      {
          rw = dc[0].ToString();
          if (rw.Contains(",")) rw = "\"" + rw + "\"";
          builder.Append(rw + ",");
      }
      builder.Append(Environment.NewLine);
    }
    return builder.ToString()
    }
