    protected void removeBlankRows()
    {
        for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    if (GridView1.Rows[i].RowType == DataControlRowType.DataRow)
                    {
                        string strtrial = Convert.Tostring(row.Cells[6].Text);
                         if(string.IsNullOrEmpty(strtrial ))
                         GridView1.DeleteRow(i);
                    }
                }
       
