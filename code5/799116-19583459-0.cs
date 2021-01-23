        public static IEnumerable<List<T>> EachCombination<T>(this List<T> allValues)
        {
            var collection = new List<List<T>>();
            for (int counter = 0; counter < (1 << allValues.Count); ++counter)
            {
                List<T> combination = new List<T>();
                for (int i = 0; i < allValues.Count; ++i)
                {
                    if ((counter & (1 << i)) == 0)
                        combination.Add(allValues[i]);
                }
                if (combination.Count == 0)
                    continue;
                yield return combination;
            }
        }
