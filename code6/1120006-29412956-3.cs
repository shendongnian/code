	public static Application GetAppDetails(AppsLight item)
    {
        using (ApplicationEntities db = new ApplicationEntities())
        {
			
            var application = (from t in db.Applications
                             where t.AppID == item.UID
                             select new MyReturnType)
				 .Include(x => x.License)
				 .FirstOrDefault();
				 
			//application should have a .License property. 
			return application;
        }
    }
