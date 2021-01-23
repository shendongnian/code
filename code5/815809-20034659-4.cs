    decimal myvalue;
    decimal sum = 0;
    for (int i = 0; i < dataGridView1.Rows.Count; ++i)
    {
        if (decimal.TryParse(dataGridView1.Rows[i].Cells[5].Value, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out myvalue))
        {
          sum += myvalue;
         }
    }
      textboxnettotal.Text = sum.ToString();
      RowCount++;
