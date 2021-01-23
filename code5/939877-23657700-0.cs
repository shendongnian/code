    string bothNames = name.Split(); // Bob + Charles
    string firstName = bothNames.First();
    string lastname = bothNames.Last();
    var query = from user in UserEntity
                where user.FirstName.Contains(firstName) || user.Surname.Contains(lastname)
                select user;
