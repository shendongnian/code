    [HttpPost]
    public ActionResult Index(HttpPostedFileBase file, string journal, long IdJournal)
    {    
        var db = new Bd_scanitEntities();
        IEnumerable<SelectListItem> items = db.JournalSet
          .Select(c => new SelectListItem
          {
              Value = c.Id.ToString(),
              Text = c.label
          });
        ViewBag.IdJournal = items;
        ScanITAPP.Service.ImageRender service = new Service.ImageRender();
        service.UploadImageToDB(file, journal, IdJournal);
        return View();
    }
