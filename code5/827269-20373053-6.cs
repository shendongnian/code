        // notice the generic constraint, as it is required now
        public static T Pop<T>() where T: Coin 
        {
            var type = typeof(T);
            // we need a cast, as the `ICoinStack` now return `Coin`
            return (T) map[type].Pop();
        }
        public static void Push<T>(T item) where T: Coin
        {
            var type = typeof(T);
            map[type].Push(item);
        }
