         protected void UpdateButton_Click(object sender, EventArgs e)
    {
        if (e.CommandName == "click")
        {
            ListViewDataItem lvd = (ListViewDataItem)((Control)e.CommandSource).NamingContainer;
            //Same two lines for each value
            Label ID = lvd.FindControl("idLabel") as Label;
            string id = id.ToString();
        }
    }
