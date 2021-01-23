    protected void ddlExampleDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList dropDownList = (DropDownList)sender;
        GridViewRow gridViewRow = (GridViewRow)dropDownList.Parent.Parent;
        string lsCustomerID = Convert.ToString(dropDownList.Attributes["CustID"]);
         if(dropDownList.SelectedValue=="Task A")
         {
             //Pass Customer ID here
             DoTaskA(lsCustomerID);
         }
         else if(dropDownList.SelectedValue=="Task B")
         {
             //Pass Customer ID here
             DoTaskB(lsCustomerID);
         }
    }
