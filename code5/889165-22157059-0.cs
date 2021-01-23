    protected void grdGrid_RowCommand(object sender, GridViewCommandEventArgs e)
            {
                Control ctl = e.CommandSource as Control;
                GridViewRow CurrentRow = ctl.NamingContainer as GridViewRow;
                int index;
    
                foreach (GridViewRow row in grdGrid.Rows)
                {
                    if (CurrentRow.RowType == DataControlRowType.DataRow)
                    {
                        //you'll have an RowIndex for each DataRow: 0,1,2 and so on
                        index = CurrentRow.RowIndex;
                    }
                    else if (CurrentRow.RowType == DataControlRowType.Footer)
                        {
                            //the RowIndex will be always -1 
                            index = CurrentRow.RowIndex;
                        }
                    
                }
            }
