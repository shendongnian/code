    public static class Extensions
    {
        public static int Rank(this int[] array, int find)
        {
            SortedList<int, object> list = new SortedList<int, object>();
            for (int i = 0; i < array.Length; i++)
            {
                list.Add(array[i], null);
            }
            if (list.ContainsKey(find))
            {
                return list.Keys.IndexOf(find);
            }
            else
            {
                return -1;
            }
        }
    }
