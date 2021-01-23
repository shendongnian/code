    public IEnumerable<info> Get()
    {
        var studentercord = _db.Student_sp().ToList();
        IEnumerable<info> data = (from item in studentercord
                                    select new info
                                    {
                                        StudentID = item.StudentID,
                                        LastName = item.LastName,
                                        FirstName = item.FirstName,
                                        EnrollmentDate = item.EnrollmentDate,
                                        MiddleName = item.MiddleName
                                    }).ToList();
     
        return data;
    }
