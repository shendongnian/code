    public class Number
    {
        public int I { get; set; } 
    }
----------
    XmlSerializer serializer = 
                new XmlSerializer(typeof(Number));
            Number number = new Number();
            StringBuilder stringBuilder
                = new StringBuilder();
            serializer.Serialize(
                new StringWriter(stringBuilder), number);
