    protected void chkCall_CheckedChanged(object sender, EventArgs e)
    {
        int i=0;
        foreach (GridViewRow gvrow in gvDetails.Rows)
        {
            CheckBox chk = (CheckBox)gvrow.FindControl("chkCall");
            if (chk != null & chk.Checked)
            {
    
                //dt.Rows.Add();
                DataRow row = dt.NewRow();
                row["shopno"] = gvDetails.Rows[i].Cells[0].Text.ToString();
                row["Lineitem"] = gvDetails.Rows[i].Cells[1].Text;
                row["Suppliername"] = gvDetails.Rows[i].Cells[2].Text;
                row["Dunsnumber"] = gvDetails.Rows[i].Cells[3].Text;
                row["AgingDays"] = gvDetails.Rows[i].Cells[4].Text;
                // row["lastfollowupmail"] = gvDetails.Rows[i].Cells[7].Text;
                dt.Rows.Add(row);
                
            }
            i++;
    
        }
    
        GridView1.DataSource = dt;
        GridView1.DataBind();
    
    }
