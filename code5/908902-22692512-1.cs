    Thing thing = new Thing{AnInt = 12, Date = new DateTimeOffset(DateTime.Now), Value = "Foo", Id = 1};
            
    gc.Cypher
        .Create("(n:Test {thingParam})")
        .WithParam("thingParam", thing)
        .ExecuteWithoutResults();
    var thingRes = gc.Cypher.Match("(n:Test)").Where((Thing n) => n.Id == 1).Return(n => n.As<Thing>()).Results.Single();
    Console.WriteLine("Found: {0},{1},{2},{3}", thingRes.Id, thingRes.Value, thingRes.AnInt, thingRes.Date);
    thingRes.AnInt += 100;
    thingRes.Value = "Bar";
    thingRes.Date = thingRes.Date.AddMonths(1);
    gc.Cypher
        .Match("(n:Test)")
        .Where((Thing n) => n.Id == 1)
        .Set("n = {thingParam}")
        .WithParam("thingParam", thingRes)
        .ExecuteWithoutResults();
    var thingRes2 = gc.Cypher.Match("(n:Test)").Where((Thing n) => n.Id == 1).Return(n => n.As<Thing>()).Results.Single();
    Console.WriteLine("Found: {0},{1},{2},{3}", thingRes2.Id, thingRes2.Value, thingRes2.AnInt, thingRes2.Date);
