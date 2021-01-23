    for(int index = 0; index < comboBox.Items.Count; index++)
    {
        var item = comboBox.Items[index];
        var businessSite = item as BusinessSite;
        if(businessSite != null && businessSite.BusinessSiteID == B.IdFromLinq)
        {
            return index;
        }
    }
