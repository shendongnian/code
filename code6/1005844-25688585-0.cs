    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridViewBind();
    }
    protected void ddlPages_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow gvrPager = GridView1.BottomPagerRow;
        DropDownList ddlPages = (DropDownList)gvrPager.Cells[0].FindControl("ddlPages");
        GridView1.PageIndex = ddlPages.SelectedIndex;
        GridViewBind();
    }
    protected void Paginate(object sender, CommandEventArgs e)
    {
        int intCurIndex = GridView1.PageIndex;        
        switch (e.CommandArgument.ToString().ToLower())
        {
            case "First":
                GridView1.PageIndex = 0;                
                break;
            case "Prev":
                GridView1.PageIndex = intCurIndex - 1;
                break;
            case "Next":
                GridView1.PageIndex = intCurIndex + 1;
                break;
            case "Last":
                GridView1.PageIndex = GridView1.PageCount - 1;
                break;
        }
        GridView1.DataBind();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Pager)
        {
            DropDownList ddl = (DropDownList)(e.Row.FindControl("ddlpages"));
            Label lblPageCount = (Label)e.Row.FindControl("lblPageCount");
            if (lblPageCount != null)
            {
                lblPageCount.Text = GridView1.PageCount.ToString();
                for (int i = 1; i <= GridView1.PageCount; i++)
                {
                    ddl.Items.Add(i.ToString());
                }
                ddl.SelectedIndex = GridView1.PageIndex;
                if (GridView1.PageIndex == 0)
                {
                    ((ImageButton)e.Row.FindControl("ImageButton1")).Visible = false;
                    ((ImageButton)e.Row.FindControl("ImageButton2")).Visible = false;
                }
                if (GridView1.PageIndex + 1 == GridView1.PageCount)
                {
                    ((ImageButton)e.Row.FindControl("ImageButton3")).Visible = false;
                    ((ImageButton)e.Row.FindControl("ImageButton4")).Visible = false;
                }
            }
        }
    }
