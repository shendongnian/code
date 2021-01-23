    var usersData = trainings
        .SelectMany(
            training => training.Subjects.Select(
                subject => new { TrainingName = training.Name, Subject = subject })
        .SelectMany(
            subject => subject.Users.Select(
                user => new { TrainingName = training.Name, SubjectName = subject.Name, User = user })
        .GroupBy(user => user.User)
        .Select(grouping => new UserData 
                    {
                        UserId = grouping.Key.UserId,
                        FullName = grouping.Key.FullName,
                        TrainingName = grouping.Select(user => user.TrainingName), 
                        SubjectName = grouping.Select(user => user.SubjectName )
                    });
