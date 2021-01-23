    var counts = testList.GroupBy(x => x.StudentId)
                         .Select(g =>
        new
        {
            StudentId = g.Key,
            TotalDays = g.Sum(gg => gg.DaysOnLecture),
            TotalLecture = g.Sum(gg => gg.LectureCount)
        });
