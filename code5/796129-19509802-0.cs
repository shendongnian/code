    public ActionResult Index(IEnumerable<HttpPostedFileBase> files) {
    for (int i =0; i < files.Length; i++) {
    if (files[i].ContentLength > 0 && i==0) {
      var fileName = Path.GetFileName(files[i].FileName);
      var path = Path.Combine(Server.MapPath("~/App_Data/uploads/Folder1"), fileName);
      file.SaveAs(path);
    }
    else if(files[i].ContentLength > 0)
    {
    var fileName = Path.GetFileName(files[i].FileName);
      var path = Path.Combine(Server.MapPath("~/App_Data/uploads/Folder2"), fileName);
      file.SaveAs(path);
    }
    }
    return RedirectToAction("Index");
    }
