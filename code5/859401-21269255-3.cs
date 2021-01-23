    var App = new { db = new {
        Tests = new[] {
            new Test { ClassID = 1, WholeYearTest = true, TestYear = 1999 },
            new Test { ClassID = 2, WholeYearTest = true, TestYear = 1999 },
            new Test { ClassID = 3, WholeYearTest = false, TestYear = 1999 },
            new Test { ClassID = 4, WholeYearTest = false, TestYear = 1999 },
        },
        StudentClasses = new[] {
            new StudentClass { ClassID = 1, StudentID = 1 },
            new StudentClass { ClassID = 1, StudentID = 2 },
            new StudentClass { ClassID = 4, StudentID = 1 },
            new StudentClass { ClassID = 3, StudentID = 2 },
        }
    } };
    var login = new { StudentID = 1, StudentYear = 1999 };
    Console.WriteLine(string.Join(Environment.NewLine, (
        //above query
      ).Select(x => string.Join(",", x.ClassID, x.WholeYearTest, x.TestYear))));
