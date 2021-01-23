    protected void RadButton1_Click(object sender, EventArgs e)
    {
    	RadTreeList1.ItemCommand -= new EventHandler<TreeListCommandEventArgs>(RadTreeList1_ItemCommand);
    
    	ContentPlaceHolder contentPage = this.Page.Master.FindControl("ContentPlaceHolder1") as ContentPlaceHolder;
    	RadButton R = sender as RadButton;
    	RadButton radbutton1 = R.Parent.FindControl("RadButton1") as RadButton;
    	CommandEventArgs e2 = new CommandEventArgs(null, radbutton1.CommandArgument);
    	TreeListCommandEventArgs e1 = new TreeListCommandEventArgs(null, radbutton1.CommandArgument, e2);
    	TreeListDataItem dataItem = e1.Item as TreeListDataItem;
    	Hashtable table = new Hashtable();
    	table["PartyParentRowId"] = (dataItem.FindControl("Label1") as Label).Text;
    	table["PartyAlias"] = (dataItem.FindControl("Label2") as Label).Text;
    }
