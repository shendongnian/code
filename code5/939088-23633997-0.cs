    var query2 = (from tc in Entities.TutorCourses
                          join c
                          in Entities.Course
                          on tc.CourseId equals c.Id
                          where tc.CourseId == id
                          select tc.Username).ToList();
    
    var query1 = Entities.User
        .Where(u => 
            query1.Any(un => un != u.Username) &&
            u.Role.Name.Contains("Tutor"))
        .Select(u => u.Role);
