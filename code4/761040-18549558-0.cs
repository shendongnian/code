    foreach (RepeaterItem item in RptBankalar.Items)
    {
        if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
        {
            HtmlInputRadioButton rbMyRadio = (HtmlInputRadioButton)item.FindControl("rbMyRadio");
            if (rbMyRadio != null && rbMyRadio.Checked)
            {
                //Do tasks
            }
        }
    }
