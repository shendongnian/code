    public abstract class Log
    {
        public class UserLog : Log
        {
            private static readonly Lazy<UserLog> _instance =
                new Lazy<UserLog>(() => new UserLog());
            public static UserLog Instance { get { return _instance.Value; } }
        }
        public class SystemLog : Log
        {
            private static readonly Lazy<SystemLog > _instance =
                new Lazy<SystemLog >(() => new SystemLog ());
            public static SystemLog Instance { get { return _instance.Value; } }
        }
    }
