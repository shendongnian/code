    private int GetColumnIndexByName(GridView grid, string name)
    {
        foreach (DataControlField col in grid.Columns)
        {
            if (col.HeaderText.ToLower().Trim() == name.ToLower().Trim())
            {
                return grid.Columns.IndexOf(col);
            }
        }
    
        return -1;
    }
    GridView1.Columns[GetColumnIndexByName(GridView1, "SchoolName")].Visible = false;
