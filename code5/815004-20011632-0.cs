    public abstract class NamedObject<T> where T : NamedObject<T>, new()
    {
        private static NamedObject<T> _instance;
        public static NamedObject<T> Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new T { objectName = typeof (T).Name };
                }
                return _instance;
            }
        }
        private string objectName;
        public string GetFullName()
        {
            return objectName + "(" + GetClassName() + ")";
        }
        protected abstract string GetClassName();
    }
