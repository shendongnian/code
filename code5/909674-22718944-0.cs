    string MyServerChecked = "Something";
    string ServiceName = service.ServiceName.ToString();
    if (dataTable != null)
    {
        foreach (DataGridViewRow row in dataTable.Rows)
        {
            if (row.Cells[0].Value != null
                && row.Cells[1].Value != null
                && string.Equals(row.Cells[0].Value.ToString(), MyServerChecked, StringComparison.OrdinalIgnoreCase)
                && string.Equals(row.Cells[1].Value.ToString(), ServiceName, StringComparison.OrdinalIgnoreCase))
            {
                // Row already exists...
            }
        }
    }
   
