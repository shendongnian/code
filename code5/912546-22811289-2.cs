    protected void GridView1_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //Find the DropDownList in the Row
            DropDownList ddlnames = (e.Row.FindControl("ddlnames") as DropDownList);
            ddlRole.DataSource = GetData("Select Item_Code,Item_Name from Pharmacy_Item_M");
            ddlRole.DataTextField = "Item_Name";
            ddlRole.DataValueField = "Item_Code";
            ddlRole.DataBind();
            //Add Default Item in the DropDownList
            ddlnames.Items.Insert(0, new ListItem("Please select"));
            //Select the role of user in DropDownList
            string x = (e.Row.FindControl("lblnames") as Label).Text;
            ddlnames.Items.FindByValue(x).Selected = true;
        }        
    }
