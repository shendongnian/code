    public static T Resolve<T>()
        {
            T ret = default(T);
            if (IsRegisteredInternal<T>())
            {
                ret = Container.Resolve<T>();
            }
            return ret;
        }
        private static bool IsRegisteredInternal<T>()
        {
            if (Container.IsRegistered<T>())
                return true;
            if (typeof(T).IsGenericType)
            {
                return Container.IsRegistered(typeof(T).GetGenericTypeDefinition());
            }
            return false;
        }
