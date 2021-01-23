    if (e.Row.RowType == DataControlRowType.DataRow)
    {
        //Find the DropDownList in the Row
        DropDownList ddlCountries = (e.Row.FindControl("ddlCountries") as DropDownList);
        ddlCountries.DataSource = GetData("SELECT DISTINCT Country FROM Customers");
        ddlCountries.DataTextField = "Country";
        ddlCountries.DataValueField = "Country";
        ddlCountries.DataBind();
 
        //Add Default Item in the DropDownList
        ddlCountries.Items.Insert(0, new ListItem("Select Country"));
    }
