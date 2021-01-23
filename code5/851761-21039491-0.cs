    [HttpPost]
    public ActionResult Edit(int id, YourViewModel model)
    {
        if (ModelState.IsValid)
        {
            var poco = repository.getPoco(id);
            Mapper.Map<YourViewModel, YourPoco>(model, poco);
            repository.Save();
            return RedirectToAction("List");
        }
        return View(model)
    }
