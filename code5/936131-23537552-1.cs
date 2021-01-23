    static class Extensions
    {
        public static void AddCustomObjects<T>(this List<T> source, List<T> list)
        {
            if(source!=null && list!=null)
                source.AddRange(list);
        }
    }
