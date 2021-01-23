        public static int CountDelimiter(string data)
        {
            var count = 0;
            var previous = char.MinValue;
            foreach (var c in data)
            {
                if (previous != '#' && c == ',')
                    count++;
                previous = c;
            }
            return count;
        }
