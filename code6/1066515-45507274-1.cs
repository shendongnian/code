    protected void btnRemove(object sender, EventArgs e)
        {
            // Check session exists 
            if (Session["Key"] != null)
            {
                // Opening / Retreiving DataTable.
                DataTable dt = (DataTable)Session["Key"];
    
                foreach (GridViewRow row in testGrid.Rows)
                {
                    CheckBox chkRow= row.Cells[0].FindControl("chkRow") as CheckBox;
    
                    if (chkRow!= null && chkRow.Checked)
                    {                    
                        int Id = Convert.ToInt32(testGrid.DataKeys[row.RowIndex].Value); 
    
                        DataRow[] drs = dt.Select("PrimaryKey = '" + Id + "'"); // replace with your criteria as appropriate
    
                        if (drs.Length > 0)
                        {
                            dt .Rows.Remove(drs[0]);
                        }
                    }
                }
    
                Session["Key"] = dt ;
                testGrid.DataSource = dt ;
                testGrid.DataBind();
            }
        }
