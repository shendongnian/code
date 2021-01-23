    IEnumerable<User> allPeople = File.ReadLines(path)
        .Select(l => l.Split(','))
        .Where(arr => arr.Length == 3)
        .Select(arr => new User
        {
            Age = int.Parse(arr[0]), // use int.TryParse to check if it's valid
            FirstName = arr[1],
            LastName = arr[2]
        });
