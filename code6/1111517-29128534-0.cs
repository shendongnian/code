    public class LazyStatic<T> where T : new()
    {
        private static T _static;
        public static T Static
        {
            get
            {
                if (_static == null) _static = new T();
                return _static;
            }
        }
    }
