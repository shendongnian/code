    using (SPSite oSite = new SPSite("siteUrl"))
    {
	   using (SPWeb oWeb = oSite.OpenWeb())
	   {
			 oWeb.AllowUnsafeUpdates = true;
             oWeb.Site.AllowUnsafeUpdates = true;
			 
			 SPList oList = oWeb.Lists["Shared Documents"];
			 SPFile file = oList.Items.Cast<SPListItem>() 
							.Select(x => x.File)
							.FirstOrDefault();
			if (file == null)
			{
				return false;
			}
			SPListItem item = file.GetListItem();
			if (item.File.Level == SPFileLevel.Checkout)
			{
				item.File.UndoCheckOut();
			}
			if (item.File.Level != SPFileLevel.Checkout)
			{
				item.File.CheckOut();
			}
			//Do update here
            //item["Content_Type"] = "lmn";
			
			item.SystemUpdate(false);
			item.File.CheckIn("SystemCheckedin");
			item.File.Publish("SystemPublished");
			
			oWeb.AllowUnsafeUpdates = false;
            oWeb.Site.AllowUnsafeUpdates = false;
		}
	}
    
