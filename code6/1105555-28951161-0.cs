    public class MyViewModel
    {
        public int PersonID { get; set; }
        public string ItemName { get; set; }
        public IEnumerable<SelectListItem> selectListItems { get; set; }
    }
    
    //Controller Method
    [HttpGet]
    public ActionResult Index()
    {
        MyViewModel model = new MyViewModel();
        model.PersonID = 0;
        model.ItemName = string.Empty;
        model.selectListItems = getSelectListItems();
        return View(model);
    }
    
    protected IEnumerable<SelectListItem> getSelectListItems ()
    {
        //... get selectlist from XML config with linq
        return query;
    }
