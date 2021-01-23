        private int MaxiumValueOfProduct(string input)
        {
            var positions = new List<int>();
            int max = 0;
            for (int i = 1; i <= input.Length; i++)
            {
                var subString = input.Substring(0, i);
                int position = 0;
                while ((position < input.Length) &&
                       (position = input.IndexOf(subString, position, StringComparison.OrdinalIgnoreCase)) != -1)
                {
                    positions.Add(position);
                    ++position;
                }
                var currentMax = subString.Length * positions.Count;
                if (currentMax > max) max = currentMax;
                positions.Clear();
            }
            return max;
        }
