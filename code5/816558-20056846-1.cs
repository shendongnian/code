    if ("it".Equals(ddl.SelectedValue.ToLower()))
    {
        ddlProv.Enabled = true;
        Page.Validate("pivaItalia");
    }
    else
    {
        ddlProv.SelectedIndex = 0;
        ddlProv.Enabled = false;
    }
