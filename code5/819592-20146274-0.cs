    foreach(var item in comboBox.Items)
    {
        var businessSite = item as BusinessSite;
        if(businessSite != null && businessSite.BusinessSiteID == B.IdFromLinq)
        {
            // your item here
        }
    }
