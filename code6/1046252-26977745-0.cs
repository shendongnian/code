    public static class Helpers
    {
        public static bool AreEquivalent(ICollection expected, ICollection actual)
        {
            if (expected == null != (actual == null))
                return false;
            if (object.ReferenceEquals((object)expected, (object)actual) || expected == null)
                return true;
            if (expected.Count != actual.Count)
                return false;
            if (expected.Count == 0 || !FindMismatchedElement(expected, actual))
                return true;
            return false;
        }
        private static bool FindMismatchedElement(ICollection expected, ICollection actual)
        {
            int nullCount1;
            Dictionary<object, int> elementCounts1 = GetElementCounts(expected, out nullCount1);
            int nullCount2;
            Dictionary<object, int> elementCounts2 = GetElementCounts(actual, out nullCount2);
            if (nullCount2 != nullCount1)
            {
                return true;
            }
            else
            {
                foreach (object key in elementCounts1.Keys)
                {
                    int expectedCount;
                    int actualCount;
                    elementCounts1.TryGetValue(key, out expectedCount);
                    elementCounts2.TryGetValue(key, out actualCount);
                    if (expectedCount != actualCount)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        private static Dictionary<object, int> GetElementCounts(ICollection collection, out int nullCount)
        {
            Dictionary<object, int> dictionary = new Dictionary<object, int>();
            nullCount = 0;
            foreach (object key in (IEnumerable)collection)
            {
                if (key == null)
                {
                    ++nullCount;
                }
                else
                {
                    int num;
                    dictionary.TryGetValue(key, out num);
                    ++num;
                    dictionary[key] = num;
                }
            }
            return dictionary;
        }
    }
