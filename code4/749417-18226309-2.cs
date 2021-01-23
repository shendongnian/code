    foreach(var column in dGV.Columns)
       sbOutput.AppendLine(Convert.ToString(column.HeaderText) + "\t");
    foreach (var row in dGV.Rows)
    {
      foreach (var cell in row.Cells)
        sbOutput.Append(Convert.ToString(cell.Value) + "\t");
      sbOutput.AppendLine();
    }
    Encoding utf16 = Encoding.GetEncoding(1254);
    byte[] output = utf16.GetBytes(sbOutput.ToString());
