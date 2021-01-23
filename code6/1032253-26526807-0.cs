    [HttpPost]
    public ActionResult Create([Bind(Include = "FirstName,LastName,MiddleName,Address,Salary,Email")]Employee u)
    {
            if (ModelState.IsValid)
            {
                Employee emp = new Employee
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    MiddleName = u.MiddleName,
                    Address = u.Address,
                    Salary = u.Salary,
                    Email = u.Email
                };
                db.Employees.Add(emp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emp);
    }
