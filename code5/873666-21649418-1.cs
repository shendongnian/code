        if (!Page.IsPostBack)
        {
            DropDownList1.DataBind();
            DropDownList2.DataBind();
        }
        Label1.Text = DropDownList2.SelectedValue;
