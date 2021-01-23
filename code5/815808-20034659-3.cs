    decimal myvalue;
    if (decimal.TryParse(dataGridView1.Rows[i].Cells[5].Value, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out myvalue))
    {
      sum += myvalue;
     }
