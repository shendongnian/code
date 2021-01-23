    foreach(Repeater rep in locationRepeater.Items)
    { 
        Repeater areaRepeater = (Repeater)rep.FindControl("areaRepeater");
        CheckBox disable = (CheckBox)rep.FindControl("checkboxid");
        foreach(Repeater areaRep in areaRepeater.Items)
        {
            HtmlGenericControl div = (HtmlGenericControl)areaRep.FindControl("div");
            div.Visible = disable.Checked;
        }
    }
