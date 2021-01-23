    [HttpGet]
    public ActionResult Test()
    {
        using (var context = new MyDataContext())
        {
            ViewBag.Roles = context.Roles.ToList();
            return View();
        }
    }
