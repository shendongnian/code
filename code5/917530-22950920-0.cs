    public List<getCourses> GetCourses()
    {
        return (from Cr in _er.Courses
                select new getCourses
                       {
                           Courseid = Cr.CourseID,
                           CourseName = Cr.CourseName,
                       }).ToList();
    }
