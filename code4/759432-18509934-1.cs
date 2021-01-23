    public ActionResult Index()
    {
            TestModels model = new TestModels();
            model.Permissions = true; //Please comment this line and check
            return View(model);
    }
    public ActionResult Grid_Read([DataSourceRequest] DataSourceRequest request)
    {
            List<TestModels> models = new List<TestModels>();
            for (int i = 0; i < 50; i++)
            {
                TestModels t1 = new TestModels();
                t1.ID = i;
                t1.Name = "Name" + i;
                models.Add(t1);
            }
            return Json(models.ToDataSourceResult(request));
    }
