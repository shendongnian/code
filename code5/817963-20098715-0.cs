    public bool IsStudentOnCourse(int studentId, int courseId)
    {
        using (var db = new DBContext()) //replace for real context..
        {
            return db.StudentsCourses.Any(x => x.StudentId == studentId && x.CourseId == courseId);
        }
    }
