    StringBuilder sbOutput = new StringBuilder();
    for (int j = 0; j < dGV.Columns.Count; j++)
       sbOutput.AppendLine(Convert.ToString(dGV.Columns[j].HeaderText) + "\t");
    for (int i = 0; i < dGV.RowCount - 1; i++)
    {
      for (int j = 1; j < dGV.Rows[i].Cells.Count; j++)
        sbOutput.Append(Convert.ToString(dGV.Rows[i].Cells[j].Value) + "\t");
      sbOutput.AppendLine();
    }
    Encoding utf16 = Encoding.GetEncoding(1254);
    byte[] output = utf16.GetBytes(sbOutput.ToString());
