    var stringA = JsonConvert.SerializeObject(a, typeof(ISample), settings);
    var stringB = JsonConvert.SerializeObject(b, typeof(ISample), settings);
    
    Console.WriteLine(stringA);
    Console.WriteLine(stringB);
