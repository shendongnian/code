    public abstract class Environment<T> where T : Environment<T>, new()
    {
        private static T _instance = new T();
        public static T Instance
        {
            get { return _instance; } // no need to cast here. It's already of type T.
        }
        public int CommonMethod()
        {
            return 1;
        }
    }
    public class Desert : Environment<Desert>
    {
        public int SandStorm()
        {
            return 12;
        }
    }
