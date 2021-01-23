    public abstract class NamedObject<ME, T> where ME : NamedObject<ME, T>, new()
    {
        private static NamedObject<ME, T> _instance;
        public static NamedObject<ME, T> Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new T { objectName = GetLabel(typeof(T)) };
                }
                return _instance;
            }
        }
        private string objectName;
        public string GetFullName()
        {
            return objectName + "(" + GetClassName() + ")";
        }
        protected abstract string GetLabel(Type type);
        protected abstract string GetClassName();
    }
