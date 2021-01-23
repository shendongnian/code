    var userTests = _uow.UserTests
        .GetAll()
        .Where(ut => ut.UserId == "0" || ut.UserId == userId)
        .Select(ut => new UserTestDTO
        {
            UserTestId = ut.UserTestId,
            UserId = ut.UserId,
            QuestionsCount = ut.QuestionsCount,
            Test = new TestDTO
            {
                TestId = ut.Test.TestId,
                Title = ut.Test.Title,
                Exam = new ExamDTO
                {
                    ExamId = ut.Test.Exam.ExamId,
                    SubjectId = ut.Test.Exam.SubjectId,
                    Name = ut.Test.Exam.Name
                }
            }
        })
        .ToList();
