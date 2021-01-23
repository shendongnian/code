    var indexQuery = 
        client.Cypher
        .Start(new {n = Node.ByIndexLookup("Persons", "name", "Chris")})
        .Return<Node<Person>>("n");
    var results = indexQuery.Results.ToList();
    Console.WriteLine("Found {0} results", results.Count());
    foreach (var result in results)
        Console.WriteLine(result.Data.Id);
