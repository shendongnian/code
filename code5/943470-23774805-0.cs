    public static class CustomExtensions
    {
        public static IEnumerable<T> ToEnumerable<T>(this T input)
        {
            yield return input;
        }
    }
