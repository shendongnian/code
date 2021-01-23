    public abstract class Log
    {
        private static volatile Dictionary<Type, Log> instances = new Dictionary<Type, Log>();
        public static TLogType GetInstance<TLogType>() where TLogType : Log, new()
        {
            TLogType instance = null;
            var type = typeof(TLogType);
            if (!Log.instances.ContainsKey(type))
            {
                instance = new TLogType();
                instances.Add(type, instance);
            }
            else
            {
                instance = (TLogType)Log.instances[type];
            }
            return instance;
        }
        protected Log() { }
    }
