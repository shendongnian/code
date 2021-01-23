    var usersData = trainings
        .SelectMany(
            training => training.Subjects.Select(
                subject => new { TrainingName = training.Name, Subject = subject })
        .SelectMany(
            subject => subject.Users.Select(
                user => 
                    new UserData 
                    {
                        UserId = user.UserId,
                        FullName = user.FullName,
                        TrainingName = subject.TrainingName, 
                        SubjectName = subject.Name 
                    }))
        .Distinct(user => user.FullName);
