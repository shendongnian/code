    protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {                  
                    if (e.Row.RowState == DataControlRowState.Edit || e.Row.RowState.ToString() == "Alternate, Edit")
                    {
                        foreach (TableCell cell in e.Row.Cells)
                        {
                            if (e.Row.Cells.GetCellIndex(cell) == 4)
                            {                                
                                ((System.Web.UI.WebControls.LinkButton)(e.Row.Cells[4].Controls[2])).ToolTip = "Tooltip goes here";
                            }
                        }
                    }
                }
            }
            catch (Exception _e)
            {
            }
        }
