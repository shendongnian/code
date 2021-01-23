    [HttpGet]
    public ActionResult Delete()
    {
      SPEFMVCEntities conn = new SPEFMVCEntities();
      var result = (from p in conn.tbl_users select p as StoredProcedureEF_MVC.Models.User).ToList();
      return View(result);
    }
