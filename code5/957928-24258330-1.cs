    var newUser = new User{Name = "3 O'clock"};
    gc.Cypher
        .Create("(u:Test {user})")
        .WithParams(new {user = newUser})
        .ExecuteWithoutResults();
    var val = gc.Cypher
        .Match("(n:Test)")
        .Return(n => n.As<User>())
        .Results
        .First();
    Console.WriteLine(val.Name);
