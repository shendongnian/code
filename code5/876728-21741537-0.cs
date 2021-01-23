    //action results
    [HttpGet]
    public ActionResult ChooseCoursePreferences()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult ChooseCoursePreferences(int CourseId)
    {
        ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Name");
        int personid = repository.GetLoggedInPersonId();
        int courseid = CourseId;
        repository.AddCoursePreferences(personid, courseid);
        return View();
    }
