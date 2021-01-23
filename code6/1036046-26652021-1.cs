    using (JsConfig.With(new Config { includeNullValues = true }))
    {
        var dto = new WrapperNullableDateTimeList
        {
            MyList = new List<DateTime?>
            {
                new DateTime(2000, 01, 01, 0, 0, 0, 0, DateTimeKind.Utc),
                null,
                new DateTime(2000, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc),
            }
        };
        var json = dto.ToJson();
        json.Print();
        Assert.That(json, Is.EqualTo(
          @"{""MyList"":[""\/Date(946684800000)\/"",null,""\/Date(978220800000)\/""]}"));
        var fromJson = json.FromJson<WrapperNullableDateTimeList>();
        Assert.That(fromJson.MyList.Count, Is.EqualTo(dto.MyList.Count));
    }
