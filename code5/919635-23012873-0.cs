     var _stud = context.Students
            .Include(p => p.studID)
            .Where(p => p.studID == "001")
            .SingleOrDefault()
        if (_stud != null)
        {
            var _course = _stud.Courses
                .FirstOrDefault();
            if (_course != null)
            {
                _course.Students.Remove(_stud);
                context.SaveChanges();
            }
        }
