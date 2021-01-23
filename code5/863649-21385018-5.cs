    var uComparer = new UserComparer();
    var distinctUsers = trainings
        .SelectMany(t => t.Subjects.SelectMany(ts => ts.Users))
        .Distinct(uComparer);
    List<UserData> userData = distinctUsers
        .SelectMany(u => 
        {
            var subjectsWithUser = trainings
                .SelectMany(t => t.Subjects
                    .Where(ts => ts.Users
                        .Any(tsu => tsu.UserId == u.UserId && tsu.FullName == u.FullName)))
                    .Select(ts => new { user = u, training = ts, subject = ts });
            return subjectsWithUser;
        })
        .GroupBy(x => x.user, uComparer)
        .Select(grp => new UserData
        {
            UserId = grp.Key.UserId, FullName = grp.Key.FullName,
            TrainingNames = grp.Select(xx => xx.training.Name).Distinct().ToList(),
            SubjectNames = grp.Select(xx => xx.subject.Name).Distinct().ToList(),
        })
        .ToList();
