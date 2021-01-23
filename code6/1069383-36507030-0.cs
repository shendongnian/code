        DataTable dt_items = new DataTable();
        dt_items.Columns.Add("Item");
        dt_items.Columns.Add("Quantity");
        if (grid_items.Rows.Count > 0)
        {
            foreach (GridViewRow row in grid_items.Rows)
            {
                dt_items.Rows.Add(row.Cells[0].Text,row.Cells[1].Text);
            }           
        }
        dt_items.Rows.Add(ddl_item.SelectedItem.Text, txt_itemAmount.Text);
        grid_items.DataSource = dt_items;
        grid_items.DataBind();
    
