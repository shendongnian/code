    List<UserData> userDataList = trainings
        .Select(training => 
        {
            var distUsers = training.Subjects.SelectMany(ts => ts.Users)  // flatten out all users
                .GroupBy(u => new { u.UserId, u.FullName})                // group by u.UserId and u.FullName
                .Select(grp => grp.First());                              // take simply the first
            return new { training, users = distUsers }; // return this anonymous type
        })
        .SelectMany(x => x.users                                          // flatten out all distinct users
            .Select(u => new UserData                                     // for each create an instance of UserData  
            {
                UserId = u.UserId,
                FullName = u.FullName,
                SubjectNames = x.training.Subjects.Select(s => s.Name).ToList(), // select only the name and create a list
                TrainingNames = x.training.Name
            }))
        .ToList();  // create the final list
