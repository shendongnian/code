    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            selectedValue = (string)Session["SelectedValue"];
        }
    }
    public void dditem_change(object sender, EventArgs e)
    {
        var ddlList = (DropDownList)sender;
        Session["SelectedValue"] = ((DropDownList)ddlList.NamingContainer.FindControl("drplist")).SelectedValue;
    }
    public void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        // selectedValue should now be accessible
    }
