    protected void rptTimeTable_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            var data = (RepeaterData)e.Item.DataItem;
            SetButtonText(e.Item, "btnMon", data.MonText);
            SetButtonText(e.Item, "btnTue", data.TueText);
            SetButtonText(e.Item, "btnWed", data.WedText);
        }
    }
    private void SetButtonText(RepeaterItem repeaterItem, string btnId, string btnText)
    {
        var btn = repeaterItem.FindControl(btnId) as Button;
        if (btn != null)
        {
            if (!string.IsNullOrEmpty(btnText))
                btn.Text = btnText;
            else
                btn.Visible = false;
        }
    }
