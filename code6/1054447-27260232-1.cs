      public static bool IsNullOrEmpty<T>(this ICollection<T> alist)
        {
            if (alist == null || alist.Count == 0){
                return true;
            }
            if (alist.Any(t => t == null)) {
                return true;
            }
            return false;
        }
