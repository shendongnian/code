    var query = context.Courses.AsQueryable();
    query = query.Include(i => i.CoursesDepartments);
    query = query.Include(i => i.CoursesDepartments.Select(cd => cd.Departments));
    
    var newQuery = query.Select(course =>  new 
    {
        ID = course.ID,
        Departments = course.CoursesDepartments.Select( cd => cd.Departments),
    });
        
    var result = query.ToList();
    
