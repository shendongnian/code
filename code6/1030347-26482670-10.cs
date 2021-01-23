    void fillData()
    {
        int maxRow = data.Count;
        int maxCol = data[0].Count;
        double factor = 1.0;
        DGV.RowHeadersVisible = false;
        DGV.ColumnHeadersVisible = false;
        DGV.AllowUserToAddRows = false;
        DGV.AllowUserToOrderColumns = false;
        DGV.CellBorderStyle = DataGridViewCellBorderStyle.None;
        //..
        int rowHeight = DGV.ClientSize.Height / maxRow - 1;
        int colWidth = DGV.ClientSize.Width / maxCol - 1;
        for (int c = 0; c < maxRow; c++) DGV.Columns.Add(c.ToString(), "");
        for (int c = 0; c < maxRow; c++) DGV.Columns[c].Width = colWidth;
        DGV.Rows.Add(maxRow);
        for (int r = 0; r < maxRow; r++) DGV.Rows[r].Height = rowHeight;
        List<Color> baseColors = new List<Color>();  // create a color list
        baseColors.Add(Color.RoyalBlue);
        baseColors.Add(Color.LightSkyBlue);
        baseColors.Add(Color.LightGreen);
        baseColors.Add(Color.Yellow);
        baseColors.Add(Color.Orange);
        baseColors.Add(Color.Red);
        List<Color> colors = interpolateColors(baseColors, 1000);
        for (int r = 0; r < maxRow; r++)
        {
            for (int c = 0; c < maxRow; c++)
            {
                DGV[r,c].Style.BackColor = 
                               colors[ Convert.ToInt16( data[r][c].Item2 * factor)];
            }
        }
    }
