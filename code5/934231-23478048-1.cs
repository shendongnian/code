    List<TrackActivity> activities = new List<TrackActivity> {
        new TrackActivity { StudentName = "Barbara", ActivityName = "juggling", ActivityScore = 9 },
        new TrackActivity { StudentName = "Barbara", ActivityName = "cycling", ActivityScore = 7 },
        new TrackActivity { StudentName = "Chris", ActivityName = "cycling ", ActivityScore = 9 },
        new TrackActivity { StudentName = "Dennis", ActivityName = "juggling ", ActivityScore = 8 },
        new TrackActivity { StudentName = "Dennis", ActivityName = "cycling ", ActivityScore = 6 },
        new TrackActivity { StudentName = "Dennis", ActivityName = "archery ", ActivityScore = 10 },
    };
    foreach (var student in activities.GroupBy(a => a.StudentName))
    {
        Console.WriteLine("{0}, {1} {2}: {3}",
                          student.Key,
                          student.Count(),
                          student.Count() > 1 ? "activities" : "activity",
                          string.Join(", ", student.Select(a => string.Format("{0} ({1})", a.ActivityName, a.ActivityScore)).ToArray()));
    }
