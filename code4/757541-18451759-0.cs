    static class MyDict {
        private static class Data<T> {
            public static readonly List<T> items = new List<T>();
        }
        public static List<T> Get<T>() { return Data<T>.items; }
        public static void Add<T>(T item) { Data<T>.items.Add(item); }
    }
