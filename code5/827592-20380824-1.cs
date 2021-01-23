    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowIndex == GridView1.EditIndex)
            {
                DropDownList ddl = (DropDownList)e.Row.FindControl("server");
                ddl.OnInit = "server_Init";                    
                try
                {
                    ddl.SelectedValue = server;
                    ddl.DataBind();
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    ddl.SelectedValue = "Order Not Available";
                    ddl.DataBind();
                }
            }
        }
    }
