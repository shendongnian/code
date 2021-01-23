    protected void UserListView_ItemCommand(object sender, ListViewCommandEventArgs e)
      {
        if (String.Equals(e.CommandName, "AddRole"))
        {
         
          ListViewDataItem dataItem = (ListViewDataItem)e.Item;
          // this will gives you Row for your list items
          Label UserNameLabel=(Label)dataItem.FindControl("UserNameLabel");
        // you can find any control on row like this
          string YourNameLabel=UserNameLabel.Text;
        }
    }
