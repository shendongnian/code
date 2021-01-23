        [HttpPost]
        public ActionResult Add_Update_Staff(MyViewModel model, string buttonType)
        {
            if (buttonType == "Insert")
            {
                if (ModelState.IsValid)
                {
                    //save a new staff info
                    return RedirectToAction("Index", "Home");
                }
            }
            if (buttonType == "Update")
            {
                foreach (var staffVm in model.ListStaffVms)
                {
                    // update each record here
                }
                return RedirectToAction("Index", "Home");
            }
            model.AvailableSalutations = (from p in db.Prm_Salutations
                                          orderby p.Desc ascending
                                          select p).ToList();
            return View(model);
        }
