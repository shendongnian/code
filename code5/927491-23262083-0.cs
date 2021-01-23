    protected void rptEventReminder_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        CheckBox cbx = e.Item.FindControl("chkComplete") as CheckBox;
        Label lbl = e.Item.FindControl("lblEid") as Label;
        if (cbx != null && lbl !=null)
        {
            Int64 eid = Convert.ToInt64(lbl.Text);
            cbx.Attributes.Add("onclick", "update("+eid");");
        }
    }
