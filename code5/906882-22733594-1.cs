    string userId = "1";
    var result = context.Tests
        .GroupJoin(context.UserTests.Where(ut => ut.UserId == userId),
            t => t.TestId,
            ut => ut.TestId,
            (t, utCollection) => new
            {
                Test = t,
                UserTests = utCollection
            })
        .SelectMany(x => x.UserTests
            .DefaultIfEmpty()
            .Select(ut => new
            {
                ExamId = x.Test.ExamId,
                TestId = x.Test.TestId,
                Title = x.Test.Title,
                UserTestId = (int?)ut.UserTestId,
                UserId = ut.UserId,
                Result = ut.Result
            }))
        .OrderBy(x => x.ExamId)
        .ThenBy(x => x.TestId)
        .ThenBy(x => x.UserTestId)
        .ToList();
