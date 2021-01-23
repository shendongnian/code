    var students = 
        _repository.Students.ToList()
                   .Select(c => 
                       new { StartDate = FixDateToCurrentYear(c.StartDate );
                             EndDate = FixDateToCurrentYear(c.EndDate); })
