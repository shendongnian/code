        var userDictionary = new Dictionary<int, List<User>>();
        userDictionary.Add(1, new List<User>
        {
            new User{ Name= "Joseph"},
        });
        IDictionary<int, IEnumerable<User>> newDictionary = userDictionary.ToDictionary(p => p.Key, p => p.Value.AsEnumerable());
        ((List<User>) newDictionary.Values.First()).Add(new User {Name = "Maria"});
        Console.WriteLine(newDictionary.Values.First().Count()); //now we have two users
