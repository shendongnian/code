    ListViewDataItem ItemToDisplay = (ListViewDataItem)e.Item;
    int UserId = (int)DataBinder.Eval(ItemToDisplay.DataItem, "UserID");
    if(UserId == 1)
    {
       HtmlTableRow newRow = (HtmlTableRow)e.Item.FindControl("TestRow");
       newRow.BgColor = "Yellow";
    }
