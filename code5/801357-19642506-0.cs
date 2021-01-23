     public static class IEnumerableExtension
        {
            public static IEnumerable<T> Intersect<T>(this IEnumerable<T> one, params IEnumerable<T>[] others)
            {
                var result = one;
                foreach (var other in others)
                    one = one.Intersect(other);
    
                return result;
            }
        }
