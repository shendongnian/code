    public ActionResult Registration()
    {
        var vm = new AssignCourseVM();
        //Student Info is hard coded. You may get it from db
        vm.StudentID = 1;
        vm.StudentName = "Scott";
        vm.Courses = GetCourseRegistations();
        return View(vm);
    }
    public List<CourseRegistration> GetCourseRegistations()
    {
        var list = new List<CourseRegistration>();
        //Hard coded for demo. You may load this list from DB
        list.Add(new CourseRegistration { CourseID = 1, CourseName = "EN" });
        list.Add(new CourseRegistration { CourseID = 2, CourseName = "GE" });
        return list;
    }
