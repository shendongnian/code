    public static class ExtensionMethods
    {
        public static bool Contains<T>(this List<T> list1, List<T> list2)
        {
            int firstIndex = list1.IndexOf(list2.First());
            int lastIndex = list1.LastIndexOf(list2.First());
            if (firstIndex == -1) return false;
            for (int i = firstIndex; i <= lastIndex; i++)
            {
                if (list1.GetRange(i, list2.Count).SequenceEqual(list2)) return true;
            }
            return false;
        }
    }
