    public ActionResult Index()
    {
        var source = _repository.GetByUserID(_applicationUser.ID);
        var model = new RefModel
        {
            test1 = source.test1,
        };
        return View("Index",model);
    }
    [HttpPost]
    public ActionResult Edit(RefModell model)
    {
        if (ModelState.IsValid)
        {
            var source = _repository.GetByUserID(_applicationUser.ID);
            if (source == null) return View(model);
            source.test1 = model.test1;
            _uow.SaveChanges();
            @ViewBag.Message = "Profile Updated Successfully";
            return Index();      
        }
        return View(model);
    }
