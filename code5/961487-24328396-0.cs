    public ActionResult Index(string sortOrder, string currentFilter, int? searchNo, int? page)
    {
        page = searchNo.HasValue ? 1 : page;
        ...
        if (searchNo.HasValue)
        {
            utilities = utilities.Where(s => s.WeekNo == searchNo.Value);
        }
        ...
    }
