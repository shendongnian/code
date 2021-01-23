    public static class Helpers
    {
        public static bool IsEquivalent(this ICollection source, ICollection target)
        {
            //These 4 checks are just "shortcuts" so we may be able to return early with a result
            // without having to do all the work of comparing every member.
            if (source == null != (target == null))
                return false; //If one is null and one is not, return false immediately.
            if (object.ReferenceEquals((object)source, (object)target) || source == null)
                return true; //If both point to the same reference or both are null (We validated that both are true or both are false last if statement) return true;
            if (source.Count != target.Count)
                return false; //If the counts are different return false;
            if (source.Count == 0)
                return true; //If the count is 0 there is nothing to compare, return true. (We validated both counts are the same last if statement).
            int nullCount1;
            int nullCount2;
            //Count up the duplicates we see of each element.
            Dictionary<object, int> elementCounts1 = GetElementCounts(source, out nullCount1);
            Dictionary<object, int> elementCounts2 = GetElementCounts(target, out nullCount2);
            //It checks the total number of null items in the collection.
            if (nullCount2 != nullCount1)
            {
                //The count of nulls was different, return false.
                return false;
            }
            else
            {
                //Go through each key and check that the duplicate count is the same for 
                // both dictionaries.
                foreach (object key in elementCounts1.Keys)
                {
                    int sourceCount;
                    int targetCount;
                    elementCounts1.TryGetValue(key, out sourceCount);
                    elementCounts2.TryGetValue(key, out targetCount);
                    if (sourceCount != targetCount)
                    {
                        //Count of duplicates for a element where different, return false.
                        return false;
                    }
                }
                //All elements matched, return true.
                return true;
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
