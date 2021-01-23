    public static bool HasDuplicates<T>(IList<T> items)
        {
            Dictionary<T, bool> map = new Dictionary<T, bool>();
            for (int i = 0; i < items.Count; i++)
            {
                if (map.ContainsKey(items[i]))
                {
                    return true; // has duplicates
                }
                map.Add(items[i], true);
            }
            return false; // no duplicates
        }
