     var tests = (from t in context.Tests
           // where !t.UsertTests.Any() //if no user took the test
             //    || t.UserTests.Any(ut=>ut.Student.StudentId == stId)
            select new {Test = t, Exam = t.Exam, 
                     UserTests = t.UserTests.Where(ut=>ut.Student.StudentId == stId))
           .ToList();
