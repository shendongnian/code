    private void Rpt_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Footer)
        {
            var lbl = (Label)e.Item.FindControl("LabelId");
            if (lbl != null)
                lbl.Text = "123.45";
        }
    }
