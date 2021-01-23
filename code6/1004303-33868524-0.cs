    using (SPSite site = new SPSite(SPContext.Current.Web.Url))                   
	{
        using (SPWeb web = site.OpenWeb())
        {
            site.AllowUnsafeUpdates = true;
            web.AllowUnsafeUpdates = true;
				
			SPList list = web.GetList["MyList"];
		    SPListItem item = list.GetItemById(myId);
         
            item["MyField"] = newValue;
            item.Update();
            web.AllowUnsafeUpdates = false;
            site.AllowUnsafeUpdates = false;
        }
    }
