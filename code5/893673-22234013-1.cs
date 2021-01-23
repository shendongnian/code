        using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
        {
            Integer idx = row.RowIndex + 1;
            if (idx < gridView1.Rows.Count) {
                GridViewRow theRow = gridView1.Rows[idx];
                //string myvar = row.Cells[0].Text;
                string myvar = theRow.Cells[0].Text;
            }
