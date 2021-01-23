    public abstract class shape
    {
        private readonly string _ID;
        public string id
        {
            get
            {
                return _ID;
            }
        }
        public string Name { get; set; }
        public shape(string id, string name)
        {
            _ID = id;
            this.Name = name;
        }
        public shape(XElement element)
        {
            _ID = element.Attribute("id").Value;
            this.Name = element.Value;
        }
        public abstract XElement GetXElement();
        public abstract double Area();
    }
