    protected void Submit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            // Do stuff...save organization
            // update the list
            BindOrganizationList();
            // select the new value
            Organizations.SelectedIndex = Organizations.Items.IndexOf(Organizations.Items.FindByText(OrganizationName.Text.ToUpper().Trim()));
            // reset the form
            ResetOrganizationForm();
            OrganizationUpdatePanel.Update();
            // set focus back to the dropdownlist
            ScriptManager scriptMgr = ScriptManager.GetCurrent(Page);
            scriptMgr.SetFocus(Organizations);
        }
        else
        {
            // Display friendly validation messages to user
        }
    }
