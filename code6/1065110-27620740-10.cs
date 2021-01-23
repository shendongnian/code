    protected void grdUser_DataBound(object sender, EventArgs e)
        {
            //...... your original code here
            //DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");
    		TextBox txtPageNumber = (TextBox)pagerRow.Cells[0].FindControl("txtPageNumber");
    		txtPageNumber.Text = grdUser.PageIndex.ToString();
            //Label pageLabel = (Label)pagerRow.Cells[0].FindControl("CurrentPageLabel");
            // if (pageList != null)
            // {
                // for (int i = 0; i < grdUser.PageCount; i++)
                // {
                    // int pageNumber = i + 1;
                    // ListItem item = new ListItem(pageNumber.ToString());
                    // if (i == grdUser.PageIndex)
                    // {
                        // item.Selected = true;
                    // }
                    // pageList.Items.Add(item);
                // }
            // }
            //...... your original code here
        }
