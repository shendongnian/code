    var sr = new StreamReader(@"C:\Users\danielc\Documents\Visual Studio 2012\Projects\TestJSON\TestJSON\response.json");
    string json = sr.ReadToEnd();
    sr.Close();
    
    var root = JsonConvert.DeserializeObject<RootObject>(json);
    var result = root.result;
    var hits = result.hits;
    
    if (hits.Any())
    {
        var address = hits.FirstOrDefault();
        var udprn = string.Format("UDPRN: {0}", address.udprn);
        Console.WriteLine(udprn);
    }
    
    Console.Read();
