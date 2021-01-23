    if (ddl.SelectedItem.Text.ToLower() == "it")
    {
        ddlProv.Enabled = true;
        Page.Validate("pivaItalia");
    }
    else
    {
        ddlProv.SelectedIndex = 0;
        ddlProv.Enabled = false;
    }
