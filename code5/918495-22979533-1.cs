          protected void GVDataEntry_RowDataBound(object sender, GridViewRowEventArgs e)
            {
    
                if (e.Row.RowType != DataControlRowType.DataRow)
                {
                    int index = GetColumnIndexByName(e.Row, "Row_Status");
                    e.Row.Cells[index].Visible = false;
                }
            }
