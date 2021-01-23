    public class MyReturnType
	{
		public Application App { get; set; }
		public License License { get; set; }
	}
	
	
	public static MyReturnType GetAppDetails(AppsLight item)
    {
        using (ApplicationEntities db = new ApplicationEntities())
        {
            var retval = (from t in db.Applications
                             join g in db.Licenses on t.LicenseID equals g.LicenseID
                             where t.AppID == item.UID
                             select new MyReturnType
							 {
								App = t,
								License = l
							 }).FirstOrDefault();
			return retVal;
        }
    }
	
