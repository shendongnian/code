            var list = new[]
            {
                "A", "16", "49", "FRED", "AD", "17", "17", "17", "FRED", "8", "B", "22", "22", "107", "64"
            };
            foreach (var strings in GetChunk(list, 5))
            {
                Console.WriteLine(strings.Length); 
            }
