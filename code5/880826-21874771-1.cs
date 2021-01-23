    //RETURN
    var query = gc.Cypher
        .Match("(p:Person)-[:HAS_PET]->(d:Dog)")
        .Return((p, d) => new {Person = p.As<Node<string>>(), Dog = d.As<Node<string>>()});
    var results = query.Results.ToList();
    foreach (var result in results)
    {
        dynamic p = JsonConvert.DeserializeObject<dynamic>(result.Person.Data);
        dynamic d = JsonConvert.DeserializeObject<dynamic>(result.Dog.Data);
        Console.WriteLine("If you find {0} (a {1}) please call {2} on {3}.", d.Name, d.Breed, p.Name, p.PhoneNumber);
    }
