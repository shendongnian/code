    foreach(Repeater rep in locationRepeater.Items)
    {
        HtmlGenericControl div = ((HtmlGenericControl)rep.FindControl("div"));
        div.Visible = chkBox.Checked;
    }
