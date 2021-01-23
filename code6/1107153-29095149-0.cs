    public ActionResult Customer(int id)
    {
        var viewModel = new Customer();
        using (var testEntities = new TestEntities(new EntityConnection(StrEntities)))
        {
            var model = testEntities.CustomerView.Single(m => m.id == id);
            viewModel.id = id;
            viewModel.address_1 = model.address_1;
            viewModel.address_2 = model.address_2;
            viewModel.post_code = model.post_code;
        }
        return View("Customer", viewModel);
    }
    [HttpPost]
    public ActionResult Address(Address viewModel)
    {
        if (ModelState.IsValid)
        {
            using (var testEntities = new TestEntities(new EntityConnection(StrEntities)))
            {
                var model = testEntities.AddressTable.Single(m => m.id == viewModel.id);
                model.address_1 = viewModel.address_1;
                model.address_2 = viewModel.address_2;
                model.post_code = viewModel.post_code;
                testEntities.SaveChanges();
            }
            return Redirect("/Customer?id=" + viewModel.id);
        }
        return View(viewModel);
    }
