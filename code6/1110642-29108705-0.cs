    int cols = 100;
    int rows = 500;
    System.Data.DataTable dt = new DataTable();
    for (int c = 0; c < cols; c++)
        dt.Columns.Add("col_" + c);
    for(int r=0;r<rows;r++)
    {
        dt.Rows.Add();
        for (int c = 0; c < cols; c++)
            dt.Rows[r][c] = String.Format("({0}:{1})", r, c);
    }
