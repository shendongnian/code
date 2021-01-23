    private void PopulateCountryChoices(FooViewModel model)
    {
        model.CountryChoices = db.Countries.Select(m => new SelectListItem
        {
            Value = m.Id.ToString(),
            Text = m.Name
        });
    }
    public ActionResult Foo()
    {
        var model = new FooViewModel();
        PopulateCountryChoices(model);
        return View(model);
    }
    [HttpPost]
    public ActionResult Foo(FooViewModel model)
    {
        if (ModelState.IsValid)
        {
            var foo = new Foo
            {
                // map properties from view model
                Countries = db.Countries.Where(m => model.SelectedCountryIds.Contains(m.Id))
            }
            db.Foos.Add(foo);
            db.SaveChanges();
           
            return RedirecToAction("Index");
        }
        // Posted form has errors
        PopulateCountryChoices(model);
        return View(model);
    }
