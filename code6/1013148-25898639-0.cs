    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                TableCell cell = e.Row.Cells[i];
                string HeaderText  = yourGridView.Columns[i].HeaderText;
                cell.Text = cell.Text.Replace(entry.Value,
                    "<span class='highlightSearchTerm'>" + entry.Value + "</span>");
                }
            }
        }
    }
