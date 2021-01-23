    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Send")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                TextBox TextBox1 = row.FindControl("txtItemGroup") as TextBox;
                Response.Redirect("yourasppage.aspx?txt=" + TextBox1.Text);
            }
        }
