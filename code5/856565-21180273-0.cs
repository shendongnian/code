     public class Список<T> : List<T>
        {
        }
        public static class Расширение
        {
            public static List<T> ПривестиКСписку<T>(this IEnumerable<T> source)
            {
                return source.ToList();
            }
        }
