    int rowTop=e.MarginBounds.Top;
    bool needMorePages=false;
    while (rowIndex<= dataGridView1.Rows.Count - 1)
    {
        DataGridViewRow row = dataGridView1.Rows[rowIndex];
        if(rowTop + row.Height >= e.MarginBounds.Top + e.MarginBounds.Height)
        {
            needMorePages = true;
            break;
        }
        foreach (DataGridViewCell Cel in GridRow.Cells)
        {
            //draw cell content
        }
        rowTop += row.Height;
        rowIndex++;
    }
    e.HasMorePages = needMorePages;
