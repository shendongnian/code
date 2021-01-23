     [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Edit")]
        public async Task<ActionResult> Edit_Post(int Id)
        {
            Employee employee = new Employee();
            employee = db.Employees.FindAsync(Id).Result;
            //if (ModelState.IsValid)
            //{
            string fileName = null;
            if (Request.Files["ImageFileToUpload"].ContentLength >0)
            {
                var file = Request.Files["ImageFileToUpload"];
                ///Saving the file to EmployeeImages folder with unique name.
                if (!string.IsNullOrEmpty(employee.PhotoPath))
                {
                    DeleteEmployeeImage(employee.PhotoPath);                    
                }
                fileName = UploadEmployeeImage(file);
                TryUpdateModel(employee);
                employee.PhotoPath = fileName;
            }
            else
            {
                TryUpdateModel(employee, null, null, new string[] { "PhotoPath" });
            }
            if (employee.DigId <= 0)
            {
                ModelState.AddModelError("DigId", "Designation is required");
            }
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            
            ViewBag.DeptIdList = new SelectList(db.Departments, "DeptId", "DeptName", employee.DeptId);
            ViewBag.DigIdList = new SelectList(db.Designations, "DegId", "DegName", employee.DigId);
            ViewBag.BranchCodeList = new SelectList(db.Branches, "BranchId", "BranchName", employee.BranchCode);
            return View(employee);
        }
 
