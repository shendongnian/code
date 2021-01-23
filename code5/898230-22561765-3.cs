    [HttpPost]
    public ActionResult Index(List<CardFileModel> card)
    {
        //Access your card file from the list. 
        var name = card.FirstOrDefault().Name;
        return View();
    }
