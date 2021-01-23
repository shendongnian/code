    foreach (DataGridViewRow row in grid_stock.Rows)
    {
        c = row.Cells[0].Value;
        if (c != null && !(bool)c)
        {
           c.Value = true;
           //here i am inserting the data to sql.,
        }
        else
        {
           c.Value = false;
        }
    }
