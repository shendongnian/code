    public ActionResult PersonInfo(int id)
    {
        var model = new Person { PersonInfo = db.GetPersonInfo().FirstOrDefault(m => m.PersonId == id)} 
        return View(model);
    }
