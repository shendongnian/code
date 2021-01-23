    public static class TestPopulate
    {
        public static void Test()
        {
            var calendar = new Calendar
            {
                Id = 42,
                CoffeeProvider = "Espresso2000",
                Meetings = new[]
                {
                    new Meeting
                    {
                        Location = "Room1",
                        From = DateTimeOffset.Parse("2014-01-01T00:00:00Z"),
                        To = DateTimeOffset.Parse("2014-01-01T01:00:00Z")
                    },
                    new Meeting
                    {
                        Location = "Room2",
                        From = DateTimeOffset.Parse("2014-01-01T02:00:00Z"),
                        To = DateTimeOffset.Parse("2014-01-01T03:00:00Z")
                    },
                }
            };
            var patch = @"{
        'coffeeprovider': null,
        'meetings': [
            {
                'location': 'Room3',
                'from': '2014-01-01T04:00:00Z',
                'to': '2014-01-01T05:00:00Z'
            }
        ]
    }";
            Patch(calendar, patch);
            Debug.WriteLine(JsonConvert.SerializeObject(calendar, Formatting.Indented));
        }
        public static void Patch<T>(T obj, string patch)
        {
            var serializer = new JsonSerializer();
            using (var reader = new StringReader(patch))
            {
                serializer.Populate(reader, obj);
            }
        }
    }
