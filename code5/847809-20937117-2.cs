    DropDownList2.DataSource = dt;
    DropDownList2.DataTextField = "College_Name";
    DropDownList2.DataValueField = "College_Name";
    DropDownList2.DataBind();
    DropDownList2.Items.Insert(0, new ListItem(String.Empty, String.Empty));
