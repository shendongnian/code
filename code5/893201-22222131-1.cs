    [Authorize(Roles = "Admin")]
    public ActionResult Delete(string id = null)
    {
        var Db = new ApplicationDbContext();
        var user = Db.Users.First(u => u.UserName == id);
        var model = new EditUserViewModel(user);
        if (user == null)
        {
            return HttpNotFound();
        }
        return View(model);
    }
      
      
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Admin")]
    public ActionResult DeleteConfirmed(string id)
    {
        var Db = new ApplicationDbContext();
        var user = Db.Users.First(u => u.UserName == id);
        Db.Users.Remove(user);
        Db.SaveChanges();
        return RedirectToAction("Index");
    }
