    if (ddl.SelectedItem.Text.ToLower() == "IT")
    {
        ddlProv.Enabled = true;
        Page.Validate("pivaItalia");
    }
    else
    {
        ddlProv.SelectedIndex = 0;
        ddlProv.Enabled = false;
    }
