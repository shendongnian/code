    // GET api/Course
    public IEnumerable<Course> GetCourses()
    {
        return db.Courses.Include((p) => p.Students).ToList();
    }
