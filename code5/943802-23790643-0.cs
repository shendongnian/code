    public ActionResult EmployeeInformation()
            {
                var query =
                from m in db.Movies
    
                join me in db.MovieEmployees
                on m.ID equals me.movieID
    
                join e in db.Employees
                on me.employeeID equals e.ID
    
                join r in db.Roles
                on me.roleID equals r.ID
    
                select new EmployeeInfoModels() { Name = e.Name, RoleType = r.RoleType, Birthdate = e.Birthday, eID = e.ID };
    
                return View(query.Distinct().ToList().Distinct());
            }
