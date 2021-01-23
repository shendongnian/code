    foreach (DataGridViewRow row in grid_stock.Rows)
    {
        var _value = row.Cells[0].Value;
        if (_value != null && !(bool)_value)
        {
           c.Value = true;
           //here i am inserting the data to sql.,
        }
        else
        {
           c.Value = false;
        }
    }
