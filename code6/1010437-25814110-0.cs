    StringBuilder sqlText = new StringBuilder();
    
    sqlText.AppendLine("select a bunch of stuff from multiple tabled");
    ...
    if (proSeries)
    {
      sqlText.AppendLine("unique sql code to add only if proSeries is true");
    }
    sqlText.AppendLine("order by these columns");
    
    string finalText = sqlText.ToString();
