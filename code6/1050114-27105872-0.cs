    class UserInfo
    {
        private static class Cache<T> where T : class
        {
            public static readonly ConditionalWeakTable<UserInfo, T> ValuesByInstance =
                new ConditionalWeakTable<UserInfo, T>();
        }
        public void SetValue<T>(T value) where T : class
        {
            Cache<T>.ValuesByInstance.Remove(this);
            Cache<T>.ValuesByInstance.Add(this, value);
        }
        public T GetValue<T>() where T : class
        {
            T value;
            Cache<T>.ValuesByInstance.TryGetValue(this, out value);
            return value;
        }
    }
