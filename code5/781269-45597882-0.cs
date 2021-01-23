    public class ListExtetions {
        public static IEnumerable<T> GetReverseEnumerator(this List<T> list) {
             for (int i = list.Count - 1; i >= 0; i--)
                   return yeild list[i];
        }
    }
