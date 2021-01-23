        [HttpPost]
        public ActionResult Edit(MyModel model)
        {
            if (ModelState.IsValid)
            {
                MyModel m = db.MyModels.Find(model.MyModelId);
                if (m.x1 != model.x1)
                    //Fire log function here
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
