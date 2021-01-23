     using (SPSite site = new SPSite(Url))
      {
        using (SPWeb web = site.OpenWeb())
        {
                   if(web.AllProperties["ButtonClick"].Equals("ButtonHasBeenCliked"))
                   {
                     // Do nothing
                   }
         }
      }
