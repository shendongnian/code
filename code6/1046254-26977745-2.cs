    public static class Helpers
    {
        public static bool IsEquivalent(this ICollection expected, ICollection actual)
        {
            //These 3 checks are just "shortcuts" so we may be able to return early with a result
            // without having to do all the work of comparing every member.
            if (expected == null != (actual == null))
                return false;
            if (object.ReferenceEquals((object)expected, (object)actual) || expected == null)
                return true;
            if (expected.Count != actual.Count)
                return false;
            //One last shortcut to see if the collection is empty then it does the heavy work of
            // comparing the two collections.
            if (expected.Count == 0 || !FoundMismatchedElement(expected, actual))
                return true;
            return false;
        }
        //This function does the actual work of comparing the two collections,
        // It builds two dictionaries with the keys being the objects in the collection and the values being the number of times we saw the key while building the dictionary.
        private static bool FoundMismatchedElement(ICollection expected, ICollection actual)
        {
            int nullCount1;
            int nullCount2;
            Dictionary<object, int> elementCounts1 = GetElementCounts(expected, out nullCount1);
            Dictionary<object, int> elementCounts2 = GetElementCounts(actual, out nullCount2);
            //It checks the total number of null items in the collection separately from the 
            // element counts.
            if (nullCount2 != nullCount1)
            {
                return true;
            }
            else
            {
                //Go through each key and check that the duplicate count is the same for 
                // both dictionaries.
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
        //Builds the dictionary out of the collection, this may be re-writeable to a ".GroupBy(" but I did not take the time to do it.
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
