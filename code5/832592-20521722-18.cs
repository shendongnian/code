        [HttpPost]
        public ActionResult UpdateStaff(MyViewModel model)
        {
            if (ModelState.IsValid)
            {
                foreach (var staffVm in model.ListStaffVms)
                {
                    // Save each record here
                }
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
