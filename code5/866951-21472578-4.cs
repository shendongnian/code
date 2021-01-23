        public ActionResult Submit(EnumViewModel model)
        {
            if (!model.CheckBoxItems.Where(p => p.IsSelected).Any())
            {
                ModelState.AddModelError("CheckBoxList", "Please select atleast one!!!");
                return View("Index",model);
            }
            return View();
        }
