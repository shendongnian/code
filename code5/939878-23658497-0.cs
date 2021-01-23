    string name = "Bob Charles";
    var namesToSearch = name.Split(' ').ToList();
    
    var UserEntities = new List<UserEntity>();
        UserEntities.Add(new UserEntity { FirstName = "Bily Bob", Surname = "Charles" }); // user1
        UserEntities.Add(new UserEntity { FirstName = "Bob", Surname = "Adam" }); // user2
        UserEntities.Add(new UserEntity { FirstName = "Anna", Surname = "Brown" }); // user3
        UserEntities.Add(new UserEntity { FirstName = "Charles", Surname = "Bob" }); // user4
