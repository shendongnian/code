    public class HtmlKeyValueAttribute : Attribute
    {
        public String Name {set;get;}
        public String Value {set;get;}
    
        public HtmlKeyValueAttribute(String name, String value)
        {
            this.Name = name;
            this.Value = value;
        }
    }
