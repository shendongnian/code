<!-- -->
    [HttpGet]
    public ActionResult Index()
    {
        var staffModel = new JsonFileService().ReadFileToModel<List<StaffModel>>(@"~/App_Data/Staff.json");
        var model = new IndexViewModel(staffModel)
            {
                Title = "Future State Mobile"
            };
        return View(model);
    }
    
