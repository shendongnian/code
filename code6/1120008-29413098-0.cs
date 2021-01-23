      public static CombinedDto GetAppDetails(AppsLight item)
    {
        using (ApplicationEntities db = new ApplicationEntities())
        {
            CombinedDto retval = (from t in db.Applications
                             join g in db.Licenses on t.LicenseID equals g.LicenseID
                             where t.AppID == item.UID
                             select(b=>new CombinedDto { ApplicationId = t, LicenceId = item})).FirstOrDefault();
            return retval;
        }
    }
    publi class CombinedDto()
    {
      public Application Application {get;set;}
      public Licence Licence {get;set;}
    }
