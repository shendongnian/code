    using E = System.Linq.Expressions.Expression; // for brevity
    // ...
    static StudentViewModel()
    {
        var s = E.Parameter(typeof(Student), "s");
        //
        // Quick hack to resolve the generic `Enumerable.Select()` extension method
        // with the correct type arguments.
        //
        var selectMethod = (Expression<Func<Student, IEnumerable<CourseViewModel>>>)
                            (_ => _.Courses.Select(c => default(CourseViewModel)));
        var lambda = E.Lambda<Func<Student, StudentViewModel>>(
            E.MemberInit(
                E.New(typeof(StudentViewModel)),
                E.Bind(
                    typeof(StudentViewModel).GetProperty("Id"),
                    E.Property(s, "Id")),
                E.Bind(
                    typeof(StudentViewModel).GetProperty("Name"),
                    E.Property(s, "Name")),
                E.Bind(
                    typeof(StudentViewModel).GetProperty("PreferredCheese"),
                    E.Property(s, "PreferredCheese")), // LOL?
                E.Bind(
                    typeof(StudentViewModel).GetProperty("Courses"),
                    E.Call(
                        ((MethodCallExpression)selectMethod.Body).Method,
                        E.Property(s, "Courses"),
                        CourseViewModel.AsViewModel))
                ),
            s);
        AsViewModel = lambda;
    }
