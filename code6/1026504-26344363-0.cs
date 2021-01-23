    public static Expression<Func<Student, StudentViewModel>> AsViewModel = x =>
            new StudentViewModel
            {
                Id = x.Id,
                Name = x.Name,
                PreferredCheese = x.PreferredCheese,
                Courses = x.Courses.Select(c => CourseViewModel.AsViewModel(c))
            }
