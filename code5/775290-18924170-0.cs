    public ActionResult Index()
    {   
        List<string> AgeList = new List<string>();
        AgeList.Add("0-17");
        AgeList.Add("18-21");
        AgeList.Add("22-25");
        AgeList.Add("26-35");
        AgeList.Add("36+");
        ViewData["Age"] = new SelectList(AgeList);
        return View();
    }
    
    [HttpPost]
    public ActionResult Index(string FirstName, string LastName)
    {
        ViewData["FirstName"] = FirstName;
        List<string> AgeList = new List<string>();
        AgeList.Add("0-17");
        AgeList.Add("18-21");
        AgeList.Add("22-25");
        AgeList.Add("26-35");
        AgeList.Add("36+");
 
        ViewData["Age"] = new SelectList(AgeList); 
        return View();
    }
