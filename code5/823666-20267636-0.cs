    public static class Extensions
    {
        public static async Task<List<T>> AsyncToList<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.ToList();
        }
    }
