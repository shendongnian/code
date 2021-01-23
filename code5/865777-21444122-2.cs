    ddlChangeStatus.Items.Add(new ListItem("Under Review", "1"));
    if (username != "jpublic")
    {
       ddlChangeStatus.Items.Add(new ListItem("Approved", "2"));
       ddlChangeStatus.Items.Add(new ListItem("Rejected", "3"));
       ddlChangeStatus.Items.Add(new ListItem("Logged", "4"));
       ddlChangeStatus.Items.Add(new ListItem("Completed", "5"));
    }
