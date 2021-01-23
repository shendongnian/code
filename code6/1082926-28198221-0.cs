    protected void PostListView_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            MembershipUser currentUser = Membership.GetUser();
            Guid currentUserId = (Guid)currentUser.ProviderUserKey;
            Button btn1 = (Button)e.Item.FindControl("deleteButton");
    
            if (currentUserId.ToString() == btn1.CommandName.ToString())
            {
                Button hdn = (Button)e.Item.FindControl("deleteButton");
                btn1.Visible = false;
            }
    
            else
            {
                Button hdn = (Button)e.Item.FindControl("deleteButton");
                btn1.Visible = false;
            }
        }
    }
