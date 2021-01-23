    [HttpGet]
    public ActionResult ViewUser(string id)
    {
        ViewUserViewModel model = new ViewUserViewModel();
        //Which user
        model.user = db.AspNetUsers.FirstOrDefault(User => User.Id == id);
        //List all courses
        model.Courses = db.Courses.OrderBy(Courses => Courses.CourseName).ToList();
        //List of courses the user is assigned to
        model.UserCoursesList = db.UserCourses.Where(UserCourses => UserCourses.UserId == id).ToList();
        //checkbox list
        model.CourseList = model.Courses.Select(Course => new SelectListItem()
        {
               Selected = model.UserCoursesList.Any(UserCourse => UserCourse.CourseId == Course.CourseID),
               Text = Course.CourseName,
               Value = Course.CourseID.ToString()
        });
        return View(model);
    }
