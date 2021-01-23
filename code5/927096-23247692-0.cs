    using(var db = new studytree_dbEntities())
    {
        Student s = db.Students
            .Where(s => s.StudentId == id)
            .Select(s => new Student {
                FirstName = s.FirstName,
                LastName = s.LastName,
                Sessions = s.Sessions.Select(session => new Session {
                    Tutors = session.Tutors
                }),
            })
            .FirstOrDefault();
        return s;
    }
