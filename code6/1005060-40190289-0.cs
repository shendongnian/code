    private EFDbContext db = new EFDbContext();
    public ActionResult Index_Read([DataSourceRequest] DataSourceRequest request)
	{
		var dataContext = db.YourEntity;
		var result = dataContext.Select(m => new
		YourViewModel
		  {
			  ID = m.ID,
			  Name= m.Name
              //code omitted for brevity
		  }
		).ToDataSourceResult(request);
		return Json(result, JsonRequestBehavior.AllowGet);
	}
