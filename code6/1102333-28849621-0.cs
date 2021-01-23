        [HttpPost]
        public ActionResult Create(userViewModel model)
        {           
            var menuIds = string.Join(",", model.MenuIds);
            var dbModel = new userViewModel();
            dbModel.User = new User();
            dbModel.User.MENU = menuIds;
           
            TryUpdateModel(dbModel);
            if (ModelState.IsValid)
            {               
                _db.Entry(dbModel.User).State = EntityState.Modified;
                _db.SaveChanges();
            }
            return RedirectToAction("Create");
        }
