    var publishedPerson = personaAsObservable.Replay(1);
    
    publishedPerson.Connect();
    publishedPerson.Subscribe(Console.WriteLine);
    publishedPerson.Subscribe(Console.WriteLine);
    publishedPerson.Subscribe(Console.WriteLine);
    publishedPerson.Subscribe(Console.WriteLine);
