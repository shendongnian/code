    public static class Extensions
    {
        public static IList<T> Clone<T>(this IList<T> SourceList) where T: ICloneable
        {
            return SourceList.Select(item => (T)item.Clone()).ToList();
        }
    }
