    [XmlInclude(typeof(Derived))]
    public class Base
    {
        public string Name { get; set; }
    }
    public class Derived : Base
    {
          
        [XmlIgnore]
        public string AnotherName { get; set; }
        public new string Name
        {
            get { return base.Name; }
            set { base.Name = value; }
        }
    }
