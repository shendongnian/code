            public ActionResult Index(int? Id)
        {
            //Get the rosters and their attendance records
                        IQueryable<Attendances> attendances = db.Attendances
                            .Where(a => a.Enrollments_Attendance == Id)
                            .Include(e => e.Enrollments.Individuals)
                            .OrderByDescending(a => a.AttendanceDate);
                        ViewBag.EnrollmentId = Id;
            try
            {
                ViewBag.FullName = attendances.First().FullName;
            
            }
            catch (InvalidOperationException ex)
            {
                ViewBag.Exception = ex;
               ViewBag.FullName = "No Attendances to display for the selected player";
            }
            
            return View(attendances.ToList());
            
        } 
   
