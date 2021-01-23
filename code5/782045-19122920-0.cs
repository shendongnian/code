    foreach (RepeaterItem item in PendingRegRepeater.Items)
    {
        if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
        {
            var checkBox = (CheckBox)item.FindControl("checkBoxID");
            checkBox.Checked = true;
        }
    }
