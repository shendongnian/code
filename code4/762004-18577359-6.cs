            var ranges = new[]
            {
                new Range(0x4e00, 0x4f80),
                new Range(0x5000, 0x9fa0),
                new Range(0x3400, 0x4db0),
                new Range(0x30a0, 0x30f0), 
                // and so on.. add any range here
            };
            for (var i = 0; i < 10000; i++)
            {
                Console.WriteLine(GenerateString(random.Next(0, 50), ranges));
            }
