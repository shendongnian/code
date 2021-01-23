    public List<getCourses>  GetCourses() {
        return _er.Courses.Select(c => 
            new getCourses {
                 Courseid = c.CourseID,
                 CourseName = c.CourseName
            }).ToList();
    }
