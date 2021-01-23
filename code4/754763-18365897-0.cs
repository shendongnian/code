    public class Page
    {
        public List<Attribute> AssociatedAttributes
        {
            get
            {
                return new List<Attribute>() { 
                    new Attribute { Value = "a" }, 
                    new Attribute { Value = "b" }, 
                    new Attribute { Value = "c" }, 
                };
            }
        }
    }
