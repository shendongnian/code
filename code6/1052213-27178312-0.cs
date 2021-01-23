        string dateString = "\"2014-06-02T21:00:00.0000000\"";
        DateTime dateRaw = new DateTime(2014, 6, 2, 21, 0, 0, 0, DateTimeKind.Unspecified);
        DateTime dateRawAsUtc = new DateTime(2014, 6, 3, 4, 0, 0, 0, DateTimeKind.Utc);
        dateRawAsUtc.Should().Be(dateRaw.ToUniversalTime());
        var oConverter = new Newtonsoft.Json.Converters.IsoDateTimeConverter();
        DateTime dateSerialized = JsonConvert.DeserializeObject<DateTime>(dateString, oConverter);
        if (dateSerialized.Kind == DateTimeKind.Unspecified)
        {
            dateSerialized = dateSerialized.ToUniversalTime();
        }
        Console.WriteLine("date string: " + dateString);
        Console.WriteLine("date serialized: " + dateSerialized.ToString("o"));
        dateSerialized.Kind.Should().Be(DateTimeKind.Utc); 
        dateSerialized.Should().Be(dateRaw.ToUniversalTime());
        dateSerialized.Should().Be(dateRawAsUtc);
