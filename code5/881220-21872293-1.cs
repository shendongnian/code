    var values = new List<string> { "321|READY|MER", "321|READY|SPL" };
    var result = values.Select(x =>
            {
                var parts = x.Split(new [] {'|' },StringSplitOptions.RemoveEmptyEntries);
                return new TestObject
                {
                    id = Convert.ToInt32(parts[0]),
                    status = parts[1],
                    type = parts[2]
                };
            }).ToArray();
