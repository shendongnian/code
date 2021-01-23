        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(employees1 employees1)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in employees1.employee_phone_manager)
                {
                    if (item.deleted)
                    {
                        db.Entry(item).State = EntityState.Deleted;
                    }
                    else if (item.phone_id == 0)
                    {
                        db.Entry(item).State = EntityState.Added;
                    }
                    else
                    {
                        db.Entry(item).State = EntityState.Modified;
                    }
                    db.SaveChanges();
                }
                db.Entry(employees1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.phonetype = new SelectList(db.phone_types, "phone_type_id", "phone_type_name");
            ViewBag.all_id = new SelectList(db.all_employees, "all_id", "all_id", employees1.all_id);
            return View(employees1);
        }
