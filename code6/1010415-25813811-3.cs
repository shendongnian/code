    public class MyObject : IXmlSerializable
    {
        //....
        public void WriteXml(XmlWriter writer)
        {
            //Call each properties "WriteAttribute" call.
            A.WriteAttribute(writer, "A");
            B.WriteAttribute(writer, "B");
        }
    }
    public class MyParam
    {
        //...
        public MyParam()
        {
            this.stringVal = string.Empty;
            this.doubleVal = double.NaN;
        }
        internal void WriteAttribute(XmlWriter writer, string name)
        {
            writer.WriteAttributeString(name, stringVal);
        }
    }
