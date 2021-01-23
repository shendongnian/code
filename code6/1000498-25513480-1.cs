    foreach (RepeaterItem ri in rptOtherNetworks.Items)
    {
        if (ri.ItemType == ListItemType.Item || ri.ItemType == ListItemType.AlternatingItem)
        {
            RadioButton r = (RadioButton)ri.FindControl("rb");
        }
    }
