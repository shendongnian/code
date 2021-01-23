    var date = new DateTime(2014, 5, 6, 17, 24, 55, DateTimeKind.Local);
    var obj = new { date = new DateTimeOffset(date) };
    JsonSerializerSettings settings = new JsonSerializerSettings();
    settings.Converters.Add(new IsoDateTimeConverter 
    { 
        DateTimeFormat = "yyyy-MM-ddTHH:mm:ssZ", 
        DateTimeStyles = DateTimeStyles.AdjustToUniversal 
    });
    string json = JsonConvert.SerializeObject(obj, settings);
    Console.WriteLine(json);
