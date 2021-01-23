       [HttpPost]
    public ActionResult Form(List<HttpPostedFileBase> files, DateTime dateParution, long IdJournal, string numEditionJournal)
    {
        var db = new Bd_scanitEntities();
        IEnumerable<SelectListItem> items = db.JournalSet
          .Select(c => new SelectListItem
          {
              Value = c.Id.ToString(),
              Text = c.label
          }).OrderBy(c => c.Text);/*_*/
        ViewBag.IdJournal = items;
        ScanITAPP.Service.ImageRender service = new Service.ImageRender();
        foreach(HttpPostedFileBase file in files){
        service.UploadImageToDB(file, dateParution, IdJournal, numEditionJournal);
       }
        return RedirectToAction("Index");
    }
