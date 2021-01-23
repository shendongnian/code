    var userTests = _uow.UserTests
        .GetAll()
        .Where(ut => ut.UserId == "0" || ut.UserId == userId)
        .Select(ut => new UserTestDTO
        {
            UserTestId = ut.UserTestId,
            UserId = ut.UserId,
            QuestionsCount = ut.QuestionsCount,
            TestId = ut.Test.TestId,
            TestTitle = ut.Test.Title,
            ExamId = ut.Test.Exam.ExamId,
            ExamSubjectId = ut.Test.Exam.SubjectId,
            ExamName = ut.Test.Exam.Name
        })
        .ToList();
