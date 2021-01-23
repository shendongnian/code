    public ActionResult Index(int ID)
    {
      var course = // get the course based on the ID
      CourseVM model = new CourseVM();
      {
        Name = course.Name,
        Enrollments = course.Enrollments.Select(e => new EnrollmentVM()
        { 
          ID = e.ID,
          Title = e.Title,
          Grade = e.Grade,
          LastName = e.LastName,
          CanDelete = e.Title != "Economics",
          ClassName = e.Grade < 2.0 ? "fail" : "pass"
        })
      };
      return View(model);
    }
