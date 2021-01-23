        [HttpPost]
        public ActionResult Edit([ModelBinder(typeof(PropertyModelBinder))]PropertyModel model)
        {
            ModelState.Clear();
            TryValidateModel(model);
            if (ModelState.IsValid)
            {
                //Save property info.              
            }
            return View(model);
        }
