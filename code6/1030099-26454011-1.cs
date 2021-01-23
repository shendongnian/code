    [Authorize]
    public ActionResult Edit(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        staffTable staffTable = db.staffTables.Find(id);
        if (staffTable == null)
        {
            return HttpNotFound();
        }
        return View(staffTable);
    }
