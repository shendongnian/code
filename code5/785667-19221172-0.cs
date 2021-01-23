        public static object ToList<T>(List<object> original)
        {
            var type = typeof(T);
            return original
                         .Select(v => (T)Convert.ChangeType(v, type, CultureInfo.InvariantCulture))
                         .ToList();
        }
