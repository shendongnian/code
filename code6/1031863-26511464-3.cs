    foreach (GridViewRow row in gvStuRoster.Rows)
    {
        double scores = 0;
        DropDownList ddlFocus = (DropDownList)row.FindControl("ddlFocus");
        DropDownList ddlEvidence = (DropDownList)row.FindControl("ddlEvidence");
        DropDownList ddlConventions = (DropDownList)row.FindControl("ddlConventions");
        Label lblScores = (Label)row.FindControl("lblScores");
        if (ddlFocus.SelectedIndex > 0)
        {
            scores += Convert.ToDouble(ddlFocus.SelectedValue);
        }
        if (ddlEvidence.SelectedIndex > 0)
        {
            scores += Convert.ToDouble(ddlEvidence.SelectedValue);
        }
        if (ddlConventions.SelectedIndex > 0)
        {
            scores += Convert.ToDouble(ddlConventions.SelectedValue);
        }
        lblScores.Text = scores == 0 ? "" : Convert.ToString(scores);
    }  
