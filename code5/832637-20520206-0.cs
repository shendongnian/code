    public class Names
    {
        private static Dictionary<int, string> Values = null;
        static Names()
        {
            Values = new Dictionary<int, string>();
            Values.Add(1, "Value of One");
            Values.Add(2, "Value of Two");
            // ...
        }
        public static string GetValue(int key)
        {
            string value;
            Values.TryGetValue(key, out value);
            return value;
        }
    };
