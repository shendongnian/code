    public class Object
    {
        private ObjectXml _xmlContext;
    
        public Object(ObjectXml xmlContext)
        {
            this._xmlContext = xmlContext;
        }
    
        public List<Person> People
        {
            get
            {
                //Person requires a constructor that takes a PersonXml object in order for this to work properly
                return this._xmlContext.People.Select(x => new Person(x)).ToList();
            }
            set
            {
                this._xmlContext.People = value.Select(x => new PersonXml(x)).ToList();
            }
        }
    
        public double Item
        {
            get { return double.Parse(this._xmlContext.Item); }
            set { this._xmlContext.Item = value.ToString(); }
        }
    }
