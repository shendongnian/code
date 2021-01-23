    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
        Person person = db.Persons.Find(id);
        var  addresses = from u in db.Addresses
                       where u.PersonID == id;
        addresses.ToList().ForEach(a => db.Addresses.Remove(a));
        db.Persons.Remove(person);
        db.SaveChanges();
        return RedirectToAction("Index");
    }
