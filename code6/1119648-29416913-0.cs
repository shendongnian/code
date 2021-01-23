    [HttpGet]
    public ActionResult ViewUser(string id)
    {
        ViewUserViewModel model = new ViewUserViewModel();
        //Which user
        model.user = db.AspNetUsers.FirstOrDefault(U => U.Id == id);
        //List all courses
        model.Courses = db.Courses.OrderBy(c => c.CourseName).ToList();
        //List of courses the user is assigned to
        model.UserCoursesList = db.UserCourses.Where(uc => uc.UserId == id).ToList();
        //checkbox list
        model.CourseList = model.Courses.Select(x => new SelectListItem()
        {
            Selected = model.UserCoursesList.Any(uc => uc.CourseId == x.CourseID),
            Text = x.CourseName,
            Value = x.CourseID.ToString()
        });
        return View(model);
    }
