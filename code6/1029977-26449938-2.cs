    int getVisibleColumn(DataGridView dgv, int x)
    {
        int cx = dgv.RowHeadersWidth;
        int c = 0;
        foreach (DataGridViewColumn col in dgv.Columns)
        {
            cx += col.Width; if ( cx >= x) return c; c++;
        }
        return -1;
    }
