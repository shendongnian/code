    if (!Page.IsPostBack)
    {
        // init dropdown here
        DMSLIB.leavetype le = new DMSLIB.leavetype();
        DropDownList2.DataSource = le.getdep();
        DropDownList2.DataValueField = "leaveID";
        DropDownList2.DataTextField = "leavetypeID";
        DropDownList2.DataBind();
    }
