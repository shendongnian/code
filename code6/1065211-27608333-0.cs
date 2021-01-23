    public class Test
    {
        public static void test()
        {
            Dictionary<string, int> d1 = new Dictionary<string, int>();
            Dictionary<string, int> d2 = new Dictionary<string, int>();
            d1.AddRange(d2);
        }
    }
    public static class Extensions
    {
        public static Dictionary<K, V> AddRange<K, V>(this Dictionary<K, V> d1, Dictionary<K, V> d2)
        {
            foreach (var kv in d2)
            {
                d1[kv.Key] = kv.Value;
            }
            return d1;
        }
    }
