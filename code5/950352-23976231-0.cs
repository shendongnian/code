    var qry = _er.Courses
        .Where( c => !c.CourseID.Contains(_er.ResultsHeader
            .Where( r => r.StudentID == 123)
            .Select(r => r.CourseID)
        )
        .Select(c => new Obj_getCourses 
        {
            Courseid = c.CourseID,
            Coursename = c.CourseName
        });
