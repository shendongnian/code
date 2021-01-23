    protected void IBNew_Click(object sender, ImageClickEventArgs e)
        {
            if (!_User.HasPermission("IMS", "T00-0001", PermissionTypes.Create))
            {
                js.ShowUPAlert(this, "Permission denied – Please contact your administrator");
            }
            else
            {
                Response.Redirect("EditCategory.aspx");
            }
    
        }
