    var json = JsonConvert.SerializeObject(date,
        Formatting.Indented,
        new JsonSerializerSettings
        {
            DateTimeZoneHandling = DateTimeZoneHandling.Local
        });
