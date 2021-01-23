    // UserDal.GetAllUsers() returns null and user is null
    var user = UserDal.GetAllUsers().MyFirstOrDefault(n => n.UsersID == 1);
    public static class IEnumerableExtensions
    {
        public static T MyFirstOrDefault<T>(this IEnumerable<T> source, 
             Func<T, bool> predicate)
        {
            if (source == null) return default(T);
            if (predicate == null) return default(T);
    
            foreach (T element in source)
            {
                if (predicate(element)) return element;
            }
            return default(T);
        }
    }
