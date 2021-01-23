    [HttpPost, ActionName("SaveChanges")]
    public ActionResult SaveChanges(
        [Bind(Prefix="MemberOrder", Include = "customerOrderLineID,customerOrderQtyMax")]
            SNW.Models.CustomerOrderInfo.MemberOrder line)
    {
        if(ModelState.IsValid)
        {
            db.Entry(line).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("CustomerOrder");
        }
        return View(line);
    }
