    protected void grdUser_DataBound(object sender, EventArgs e)
        {
            //...
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
            //...
        }
