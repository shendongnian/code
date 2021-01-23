    public ActionResult Index(string searchTerm = "", string sort, int page = 1)
    {
        string withOutSpace = searchTerm.Trim();
        ViewBag.searchTerm = searchTerm;
        int pagesize;
        bool succeed = int.TryParse(System.Web.Configuration.WebConfigurationManager.AppSettings["TechPageSize"], out pagesize);
        var racks = repository.AllFind(withOutSpace);
        if(sort == "price")
        {
             racks = racks.OrderBy(a => a.Technology.Price);
        }
        else if(sort == "date")
        {
              racks = racks.OrderBy(a => a.Technology.Date);
        }
        else
        {
              racks = racks.OrderBy(a => a.Technology.SerialNumber);
        }
        racks = racks.ToPagedList(page, pagesize)
