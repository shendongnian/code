    public ActionResult Index(int? Id )
    {
        //Get the rosters and their attendance records
        IQueryable<Attendances> attendances = db.Attendances
            .Where(a => a.Enrollments_Attendance == Id)
            .Include(e => e.Enrollments.Individuals)
            .OrderByDescending(a => a.AttendanceDate);
        ViewBag.EnrollmentId = Id;
        ViewBag.FullName = ...; // logic to get FullName here
        var sql = attendances.ToString();
        return View(attendances.ToList());
    }
