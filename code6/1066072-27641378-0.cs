    var arrayOne = new[] {"Germane", "Henry", "Charissa", "Evan", "Zorita"};
    var arrayTwo = new[] {"Athena", "Darryl", "Zelenia", "Honorato", "Macon"};
    // bind to an empty sequence to start with
    var source = new List<string>();
    var query = source.Where (x => x.Length > 3);
    if (true)
    {
        query = query.Where (x => x.Length % 2 == 0);
    }
    // change the sequence once
    source.AddRange(arrayOne);
    var resultOne = query.ToArray();    
    Console.WriteLine(string.Join(", ", resultOne));
    // change the sequence again
    source.Clear();
    source.AddRange(arrayTwo);
    var resultTwo = query.ToList();
    Console.WriteLine(string.Join(", ", resultTwo));
