    [HttpPost]
    public ActionResult CreateMyModels(List<MyModel> myModels)
    {
        if (ModelState.IsValid)
        {
            foreach (var myModel in myModels)
            {
                db.MyModels.Add(myModel);
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(myModels);
    }
