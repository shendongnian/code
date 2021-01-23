    protected void Grid_ItemList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        Connection con = new Connection();     
        if (e.Row.RowType == DataControlRowType.DataRow)
            {
            //Find the DropDownList in the Row
            DropDownList ddlnames = (e.Row.FindControl("ddlnames") as DropDownList);
            ddlnames.DataSource = con.GetData("Select Item_Code,Item_Name from mytable");
            //TextValue Pairs of DropDown list
            ddlnames.DataTextField = "Item_Name";
            ddlnames.DataValueField = "Item_Code";
            ddlnames.DataBind();
            //Add Default Item in the DropDownList
            ddlnames.Items.Insert(0, new ListItem("Please select"));
            }        
        }
