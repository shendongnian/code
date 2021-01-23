    public ActionResult _Deleted()
    {
        List<DeletedRecord> li = ws.GetDeleteds().ToList();
        var ura = li;
        return PartialView(ura); // Not View(ura)
    }
