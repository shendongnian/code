    private List<MyObject> myList;
    protected override void Initialize(RequestContext requestContext)
    {
        myList = GetAllData();
    }
    public ActionResult Index()
    {
        MyViewModel model = new MyViewModel();
        model.List = myList;
        return View(model);
    }
    public JsonResult GetData(int i)
    {
        return Json(myList.Where(x => x.Data == i));
    }
