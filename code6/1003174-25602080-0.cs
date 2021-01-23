    using (var stream = new MemoryStream()) {
        var stats = new Statistics {
            DateTimeAsUtc = DateTime.UtcNow,
            TopWords = new List<StatisticsRow> {
                new StatisticsRow { Count = 1, Key = "abc" }
            },
            TopHashTags = new List<StatisticsRow> {
                new StatisticsRow { Count = 2, Key = "def" }
            }
        };
        Serializer.Serialize(stream, stats);
        stream.Seek(0, SeekOrigin.Begin);
        var deserialized = Serializer.Deserialize<Statistics>(stream);
        Console.WriteLine(deserialized.DateTimeAsUtc);
        foreach(var row in deserialized.TopWords)
            Console.WriteLine("{0}: {1}", row.Key, row.Count);
        foreach (var row in deserialized.TopHashTags)
            Console.WriteLine("{0}: {1}", row.Key, row.Count);
    }
