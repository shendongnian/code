    private List<SelectListItem> GetEmailList()
    {
        var emailLst = (from f in db.Uchets
                        orderby f.Adress
                        where f.DateVoz < DateTime.Now
                        select new SelectListItem
                        {
                            Text = f.Adress,
                            Value = f.Adress
                        }).Distinct().ToList();
    
        return emailLst;
    }
    
    public ActionResult Index(string nameEmail)
    {
        ViewBag.nameEmail = GetEmailList();
        return View();
    }
    
    [HttpPost]
    public ActionResult Index(MvcLibraly.Models.MailModel objModelMail, HttpPostedFileBase fileUploader)
    {
        if (ModelState.IsValid)
        {
            // ...
        }
        else
        {
            ViewBag.nameEmail = GetEmailList();
            return View();
        }
    }
