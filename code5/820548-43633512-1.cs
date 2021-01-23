    public ActionResult Search(int id)
    {
        var query = dbentity.user.Where(c => c.UserId == id);
        return Json(RenderViewToString(this.ControllerContext, "Search", query));
    }
