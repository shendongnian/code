        public static IEnumerable<T> Nullable<T>(this IEnumerable<T> obj)
        {
            if (obj == null)
                return new List<T>();
            else
                return obj;
        }
