    var settings = new Settings(){
       ConnectionString = "blah blah blah",
       DatabaseName = "blah blah blah",
       Started = DateTime.Now,
    }
    var json = JsonConvert.SerializeObject(settings);
    File.WriteAllText(@"C:/Settings.txt", json);
