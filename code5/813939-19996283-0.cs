    protected void rowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            for (int i = 0; i < e.Row.Controls.Count; i++)
            {
                var headerCell = e.Row.Controls[i] as DataControlFieldHeaderCell;
                if (headerCell != null)
                {
                    if (headerCell.Text == "name_of_id_column")
                    {
                        headerCell.Visible = false;
                        Page.Items["IDCellIndex"] = i;
                        break;
                    }
                }
            }   
        }
        else if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Footer)
        {
            int idCellIndex = Convert.ToInt32(Page.Items["IDCellIndex"]);
    
            e.Row.Controls[idCellIndex].Visible = false;
        }
    }
