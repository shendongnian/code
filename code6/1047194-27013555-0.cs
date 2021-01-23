    protected void grduser_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Update")
            {
                DataTable dt = (DataTable)ViewState["dtable"];
    
                Int32 index = Convert.ToInt32(e.CommandArgument);
    
                GridViewRow row = grduser.Rows[index];
                dt.Rows[row.DataItemIndex]["userid"] = row.Cells[0].Text;
                dt.Rows[row.DataItemIndex]["username"] = ((TextBox)(row.FindControl("txtuname"))).Text;
                dt.Rows[row.DataItemIndex]["usertype"] = row.Cells[2].Text;
                dt.Rows[row.DataItemIndex]["email"] = row.Cells[3].Text;
                dt.Rows[row.DataItemIndex]["salary"] = ((TextBox)(row.FindControl("txtsalary"))).Text;
                grduser.EditIndex = -1; 
                ViewState["dtable"]=dt;
                grduser.DataSource = (DataTable)(ViewState["dtable"]);
                grduser.DataBind();
    
            }
    
        }
