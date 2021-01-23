    if (list.GetItems(query).GetDataTable() != null)
    {
        using (DataTableReader rdr = list.GetItems(query).GetDataTable().CreateDataReader())
        {
            while (rdr.Read())
            {
                TextBox1.Text = rdr["Name"].ToString();
            }
        }
    }
