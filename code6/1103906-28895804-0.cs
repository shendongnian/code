     [HttpPost]
        public ActionResult Edit(EditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                WorkerServices.PostEditViewModel(model);
                return RedirectToAction("Index");
            }
