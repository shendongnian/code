         foreach (GridViewRow row in GrdProduct.Rows)
         {
            if (row.RowType == DataControlRowType.DataRow)
            {
                Label lblproduct = (Label)row.FindControl("lblProduct");
                CheckBox chkSelect = (CheckBox)row.FindControl("chkSelectAll");
    
                chkSelect.Checked = false;
                for (int rowIndex = 0; rowIndex < dt.Rows.Count || !chkSelect.Checked; rowIndex++)
                {
                    DataRow r = dt.Rows[rowIndex];
    
                    if (Convert.ToString(r["productName"]) == lblproduct.Text)
                    {
                        chkSelect.Checked = true;
    
                    }
                }
    
            }
