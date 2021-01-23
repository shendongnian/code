        public static int CountDelimiter(string data)
        {
            var count = 0;
            var previous = char.MinValue;
            foreach (var c in data)
            {
                if (previous != '#' && preivous !='0' && c == ',')
                    count++;
                previous = c;
            }
            return count;
        }
