    public class MyAttributeAttribute : Attribute
    {
        public MyAttributeAttribute(string value)
        {
            Value=value;
        }
        public string Value { get; private set; }
    }
    public class MyDto
    {
        [MyAttribute("attribute1")]
        public string Property1 { get; set; }
        [MyAttribute("attribute2")]
        public string Property2 { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyDto dto=new MyDto() { Property1="Value1", Property2="Value2" };
            string value=GetValueOf<string>(dto, "attribute1");
            // value = "Value1"
        }
        public static T GetValueOf<T>(MyDto dto, string description)
        {
            if(string.IsNullOrEmpty(description))
            {
                throw new InvalidOperationException();
            }
            var props=typeof(MyDto).GetProperties().ToArray();
            foreach(var prop in props)
            {
                var atts=prop.GetCustomAttributes(false);
                foreach(var att in atts)
                {
                    if(att is MyAttributeAttribute)
                    {
                        string value=(att as MyAttributeAttribute).Value;
                        if(description.Equals(value))
                        {
                            return (T)prop.GetValue(dto, null);
                        }
                    }
                }
            }
            return default(T);
        }
    }
