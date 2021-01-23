    string[] aPOS = new string[] { "11", "11", "18", "18", "11", "11"};
            var count = new Dictionary<string, int>();
            foreach (string value in aPOS)
            {
                if (count.ContainsKey(value))
                {
                    count[value]++;
                }
                else
                {
                    count.Add(value, 1);
                }
            }
            string mostCommonString = String.Empty;
            int highestCount = 0;
            foreach (KeyValuePair<string, int> pair in count)
            {
                if (pair.Value > highestCount)
                {
                    mostCommonString = pair.Key;
                    highestCount = pair.Value;
                }
            }            
