    table.Columns.Add("Total", typeof(decimal));
    foreach (DataRow row in table.Rows)
    {
        decimal rowSum = 0;
        foreach (DataColumn col in table.Columns)
        {
            if(!row.IsNull(col))
            {
                string stringValue = row[col].ToString();
                decimal d;
                if(decimal.TryParse(stringValue, out d))
                    rowSum += d;
            }
        }
        row.SetField("Total", rowSum);
    }
