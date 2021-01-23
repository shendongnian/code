    using (var site = new SPSite(siteUrl))
    {
        using (var web = site.OpenWeb())
        {
            var list = web.Lists.TryGetList(listTitle);
            var item = list.GetItemById(itemId);
            var eventDescField = list.Fields.GetFieldByInternalName("Description");
            var eventDesc = item[eventDescField.Id];
            var eventDescText = eventDescField.GetFieldValueAsText(eventDesc);
        }
    }
