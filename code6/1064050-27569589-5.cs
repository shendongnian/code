    protected void grdUser_DataBound(object sender, EventArgs e)
            {
                GridViewRow pagerRow = grdUser.BottomPagerRow;
                DropDownList pageSizeList = (DropDownList)pagerRow.Cells[0].FindControl("ddlPageSize");
                if (Context.Session["PageSize"] != null)
                {
                    pageSizeList.SelectedValue = Context.Session["PageSize"].ToString();
                }
                DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");
                Label pageLabel = (Label)pagerRow.Cells[0].FindControl("CurrentPageLabel");
    
                if (pageList != null)
                {
                    for (int i = 0; i < grdUser.PageCount; i++)
                    {
                        int pageNumber = i + 1;
                        ListItem item = new ListItem(pageNumber.ToString());
                        if (i == grdUser.PageIndex)
                        {
                            item.Selected = true;
                        }
                        pageList.Items.Add(item);
                    }
                }
    
                if (pageLabel != null)
                {
                    int currentPage = grdUser.PageIndex + 1;
                    pageLabel.Text = "View " + currentPage.ToString() + " of " + grdUser.PageCount.ToString();
                }
            }
    protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
            {
                GridViewRow pagerRow = grdUser.BottomPagerRow;
                DropDownList pageSizeList = (DropDownList)pagerRow.Cells[0].FindControl("ddlPageSize");
                //
    
                grdUser.PageSize = Convert.ToInt32(pageSizeList.SelectedValue);
                Context.Session["PageSize"] = pageSizeList.SelectedValue;
                BindGrid();
            }
            protected void PageDropDownList_SelectedIndexChanged(object sender, EventArgs e)
            {
                GridViewRow pagerRow = grdUser.BottomPagerRow;
                DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");
                grdUser.PageIndex = pageList.SelectedIndex;
                BindGrid();
            }
     protected void PreRenderGrid(object sender, EventArgs e)
            {
                GridViewRow pagerRow = grdUser.BottomPagerRow;
                DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");//error
                Label pageLabel = (Label)pagerRow.Cells[0].FindControl("CurrentPageLabel");
                if (pageList != null)
                {
                    for (int i = 0; i < grdUser.PageCount; i++)
                    {
                        int pageNumber = i + 1;
                        ListItem item = new ListItem(pageNumber.ToString());
                        if (i == grdUser.PageIndex)
                        {
                            item.Selected = true;
                        }
                        pageList.Items.Add(item);
                    }
                }
                if (pageLabel != null)
                {
                    int currentPage = grdUser.PageIndex + 1;
                    pageLabel.Text = "View " + currentPage.ToString() + " of " + grdUser.PageCount.ToString();
                }
                this.grdUser.Controls[0].Controls[this.grdUser.Controls[0].Controls.Count - 1].Visible = true;
                BindGrid();
            }
        
