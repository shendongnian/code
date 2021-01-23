       using (SPSite site = new SPSite(this.siteUrl))
        {
        	using (SPWeb web = site.OpenWeb(this.siteName))
        	{
        		SPList mylib = web.Lists[this.libraryName];
        		DataTable dt = mylib.Items.GetDataTable();
        	}
        }
