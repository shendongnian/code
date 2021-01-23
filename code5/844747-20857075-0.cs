    GridView.Rows.Count
    just use a simple int to iterate 
    int i = 0;
    foreach(GridViewRow row in  temp_gridView.Rows)
    {
    box.Item_id = temp_gridView.Rows[i].Cells[0].Text;
    box.Quantity = temp_gridView.Rows[i].Cells[1].Text;
    box.Total = temp_gridView.Rows[i].Cells[2].Text;
    i++;
    }
