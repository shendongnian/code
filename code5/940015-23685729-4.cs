    public class Country
    {
        private string _name;
        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }
        public ObservableCollection<State> States { get; set; }
    }
    public class State
    {
        private readonly Dictionary<string, object> _info = new Dictionary<string, object>();
     
        /// <summary>
        /// Attributes of the state can be added dynamically (key will be the attribtue name etc...)
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object this[string key]
        {
            get
            {
                return this._info[key];
            }
            set
            {
                this._info[key] = value;
            }
        }
        public string StateName { get; set; }
    }
