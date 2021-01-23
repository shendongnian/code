        private static string GenerateString(int length, IList<Range> ranges) 
        {
            var builder = new StringBuilder(length);
            var random = new Random();
            for (var i = 0; i < length; i++)
            {
                var rangeIndex = random.Next(ranges.Count);
                var range = ranges[rangeIndex];
                builder.Append((char)random.Next(range.Begin, range.End));
            }
            return builder.ToString();
        }
