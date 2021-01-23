    foreach(Repeater rep in locationRepeater.Items)
    { 
        Repeater areaRepeater = ((Repeater)rep.FindControl("areaRepeater"));
        foreach(Repeater areaRep in areaRepeater.Items)
        {
            HtmlGenericControl div = ((HtmlGenericControl)areaRep.FindControl("div"));
            div.Visible = chkBox.Checked;
        }
    }
