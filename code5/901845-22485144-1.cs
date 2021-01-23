    public ActionResult Index(string searchTerm = "", string sort, bool asc, int page = 1)
    {
        string withOutSpace = searchTerm.Trim();
        ViewBag.searchTerm = searchTerm;
        int pagesize;
        bool succeed = int.TryParse(System.Web.Configuration.WebConfigurationManager.AppSettings["TechPageSize"], out pagesize);
        var racks = repository.AllFind(withOutSpace);
    
        if(asc)
        {
            switch(sort)
            {
                case "price":
                    racks = racks.OrderBy(a => a.Technology.Price);
                    break;
                case "date":
                    racks = racks.OrderBy(a => a.Technology.Date);
                    break;
                case default:
                    racks = racks.OrderBy(a => a.Technology.SerialNumber);
                    break;
            }
        }
        else
        {
            switch(sort)
            {
                case "price":
                    racks = racks.OrderByDescending(a => a.Technology.Price);
                    break;
                case "date":
                    racks = racks.OrderByDescending(a => a.Technology.Date);
                    break;
                case default:
                    racks = racks.OrderByDescending(a => a.Technology.SerialNumber);
                    break;
            }
        }
        racks = racks.ToPagedList(page, pagesize)
