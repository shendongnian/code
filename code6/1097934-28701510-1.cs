    void Foo(IEnumerable<Test> tests) {
       var result = from t in tests
                    where t.Teachers.Count() > 10
                    select new {
                        Test = t,
                        TeacherCount = t.Teachers.Count(),
                        SchoolCount = t.Schools.Count()
                    };
    }
