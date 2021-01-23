    public IEnumerable<CourseDTO> MyMethod(int Id) 
    {
        return from p in db.Students.Find(Id).Courses
               select new CourseDTO
               {
                   Id = p.Id,
                   CourseName = p.CourseName
               };
    }
