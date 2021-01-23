	public static Tuple<Application, License> GetAppDetails(AppsLight item)
    {
        using (ApplicationEntities db = new ApplicationEntities())
        {
            var tuple = (from t in db.Applications
                             join g in db.Licenses on t.LicenseID equals g.LicenseID
                             where t.AppID == item.UID
                             select Tuple.Create(t, l))
						 .FirstOrDefault();
			return tuple;
			//access the items in the tuple like this: tuple.Item1; tuple.Item2;
        }
    }
