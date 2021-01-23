    int rowTop=ev.MarginBounds.Top;
    bool needMorePages=false;
    while (rowIndex<= dataGridView1.Rows.Count - 1)
    {
        DataGridViewRow row = dataGridView1.Rows[rowIndex];
        if(rowTop + row.Height >= ev.MarginBounds.Top + ev.MarginBounds.Height)
        {
            needMorePages = true;
            break;
        }
        foreach (DataGridViewCell cell in row.Cells)
        {
            //draw cell content
        }
        rowTop += row.Height;
        rowIndex++;
    }
    ev.HasMorePages = needMorePages;
