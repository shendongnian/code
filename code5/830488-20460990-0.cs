    // Disable buttons if user does not have admin security level
    if (Session["SecurityLevel"] != "A")
    {
        rowToHide.Visible = false;
        linkbtnNewEmployee.Visible = false;
        imgbtnNewEmployee.Visible = false;
        linkbtnViewUserActivity.Visible = false;
        imgbtnViewUserActivity.Visible = false;
        linkbtnEditEmployees.Visible = false;
        imgbtnEditEmployees.Visible = false;
        linkbtnManageUsers.Visible = false;
        imgbtnManageUsers.Visible = false;
    }
