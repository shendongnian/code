    var events = Newtonsoft.Json.JsonConvert.DeserializeObject<List<EmailEvent>>(System.IO.File.ReadAllText(@"z:\temp\test.json"));
    
    foreach (var ev in events)
    {
        Console.WriteLine(ev.SmtpId);
    }
