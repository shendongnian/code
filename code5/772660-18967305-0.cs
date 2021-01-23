    public ActionResult Edit(ProductViewModel model) {
        if (ModelState.IsValid)
        {
            var product = JsonConvert.DeserializeObject<Product>(JsonConvert.SerializeObject(model));
            Database.Entry(product).State = EntityState.Modified;
            Database.SaveChanges();
        }
        return View(model);
    }
