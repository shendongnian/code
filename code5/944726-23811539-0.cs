    [HttpGet]
    public ActionResult Search(string searchString)
    {
        var searchResult = DbSession.QueryOver<Translation>()
                                .WhereRestrictionOn(x => x.Value).IsLike(searchString)
                                .List(); 
        return Json(searchResult, JsonRequestBehavior.AllowGet);
    }
