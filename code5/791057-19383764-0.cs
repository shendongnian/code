	using (SPSite oSPsite = new SPSite("http://xxxxxxxxxx:20000/sites/myWA/test"))
	{                    
		using (SPWeb oSPWeb = oSPsite.OpenWeb())
		{
			SPList oTransDataList = oSPWeb.Lists["MyDataList"];
			oSPWeb.AllowUnsafeUpdates = true;                        
			List<Guid> ids = new List<Guid>();
			SPViewCollection oViewCollection = oTransDataList.Views;
			foreach (SPView oViewColl in oViewCollection)
			{
				if (oViewColl.Title == "MyCustomView")
				{
					ids.Add(oViewColl.ID);
				}
		    }
			foreach (Guid id in ids)
			{
				oViewCollection.Delete(id);
			}
		}
	}
