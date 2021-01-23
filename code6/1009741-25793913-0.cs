    vm.repository.northwind.Products.Add(vm.Product);
------------------
    [HttpPost]
    public ActionResult ProductCreate(FormCollection fc)
    {
        var vm = PopulateProductEditViewModel(null);
        UpdateModel(vm.Product, "Product");
        vm.repository.northwind.Products.Add(vm.Product);
        vm.repository.Save();
        return RedirectToAction("ProductList");
    }
