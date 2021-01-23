    public ActionResult Details([Bind(Prefix="id")]string u)
    {
        if (u == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        AspNetUser user = db.AspNetUsers.Find(u);
        if (user == null)
        {
            return HttpNotFound();
        }
        return View(user);
    }
