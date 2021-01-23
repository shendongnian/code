        public static class Singletone<T>
        where T : class, new()
    {
        /// <summary>
        /// The syncRoot.
        /// </summary>
        private static readonly object syncRoot = new object();
        /// <summary>
        /// The instance.
        /// </summary>
        private static volatile T instance;
        /// <summary>
        /// Gets the instance.
        /// </summary>
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new T();
                        }
                    }
                }
                return instance;
            }
        }
    }
