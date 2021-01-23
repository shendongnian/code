    [DataContract()]
    public class SharedObjects
    {
        public static SharedObjects Instance;
        public SharedObjects()
        {
            Objects = new Dictionary<string, object>();
        }
        public void Init()
        {
            Objects["mainviewmodel"] = new PersonListViewModel();
        }
        [DataMember()]
        private Dictionary<string, Object> _Objects;
        public Dictionary<string, Object> Objects
        {
            get { return _Objects; }
            set { _Objects = value; }
        }
    }
