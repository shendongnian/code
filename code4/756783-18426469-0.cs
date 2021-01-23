    protected void btnSave_Click(object sender, EventArgs e)
    {
        var o = new UserDto
                    {
                        DisplayName = txtName.Text,
                        Email = txtEmail.Text,
                        Username = txtUsername.Text,
                        Password = txtPassword.Text,
                        TimeZoneId = ddZones.SelectedValue,
                        Id = Session["SelectedUserId"] == null ? 0 : int.Parse(Session["SelectedUserId"].ToString())
                    };
        var result = new UserService(Common.CurrentUserId()).SaveUser(o);
        if (result.Success == false)
        {
            // Define the name and type of the client scripts on the page.
            String csname1 = "MessageBoxScript";
            Type cstype = this.GetType();
            // Get a ClientScriptManager reference from the Page class.
            ClientScriptManager cs = Page.ClientScript;
            // Check to see if the startup script is already registered.
            if (!cs.IsStartupScriptRegistered(cstype, csname1))
            {
                StringBuilder cstext1 = new StringBuilder();
                cstext1.Append("<script type=text/javascript> $.msgBox({title: 'Unable to save',content: 'An error has occured while saving the object.'}); </");
                cstext1.Append("script>");
                cs.RegisterStartupScript(cstype, csname1, cstext1.ToString());
            }
        }
        Response.Redirect("users.aspx");
    }
