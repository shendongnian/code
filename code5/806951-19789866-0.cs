      public static bool IsNullOrEmpty(this IList collection)
        {
            if (collection == null)
                return true;
            return collection.Count == 0;
        }
