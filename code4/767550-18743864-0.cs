       using (SPSite site = new SPSite(this.SiteUrl))
        {
        	using (SPWeb web = site.OpenWeb(this.SiteName))
        	{
        		SPList mylib = web.Lists[this.libraryName];
        		DataTable dt = mylib.Items.GetDataTable();
        	}
        }
