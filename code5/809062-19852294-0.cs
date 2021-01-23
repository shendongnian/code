    public static class MyExtensions
    {
        public static IEnumerable<T> Duplicates<T>(this IEnumerable<T> input)
        {
            var a = new HashSet<T>();
            var b = new HashSet<T>();
            foreach(var x in input)
            {
                if (!a.Add(x) && b.Add(x))
                    yield return x;
            }
        }
    }
