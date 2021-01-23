    var res = testData
        .GroupBy(test => test.TestCaseName)
        .Select(g => new ResultProperties {
            TestCaseName = g.Key
        ,   Screen = g.Select(test => test.Screen).FirstOrDefault()
        ,   IEStatus = g.Select(test => test.IEStatus).FirstOrDefault()
        ,   IEPath = g.Select(test => test.IEPath).FirstOrDefault()
        ,   FFStatus = g.Select(test => test.FFStatus).FirstOrDefault()
        ,   FFPath = g.Select(test => test.FFPath).FirstOrDefault()
        ,   GCStatus = g.Select(test => test.GCStatus).FirstOrDefault()
        ,   GCPath = g.Select(test => test.GCPath).FirstOrDefault()
        }).ToList();
