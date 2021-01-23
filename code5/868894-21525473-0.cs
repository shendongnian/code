    [HttpGet]
    public ActionResult ShowMyAtdByDate()
    {
        int empId = 0;
        int.TryParse((string)Session["Employee"], out empId);
        if (empId <= 0)
        {
            return RedirectToAction("IsAuth_Page", "Home");
        }
        return View();
    }
    [HttpPost]
    public ActionResult ShowMyAtdByDate(string dateFrom, string dateTo)
    {
        if (dateFrom != "" && dateTo == "" && empId > 0)
        {
            ...
        }
        else if (dateFrom == "" && dateTo != "" && empId > 0)
        {
            ...
        }
        etc...
    }
