    s => new StudentViewModel {
        Id = s.Id,
        Name = s.Name,
        PreferredCheese = s.PreferredCheese,
        Courses = s.Courses.Select(x => new CourseViewModel { Id = x.Id, Name = x.Name })
    }
