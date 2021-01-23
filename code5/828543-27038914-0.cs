    [DataContract]
    public class TestBusinessObject : BusinessObjectBase
    {
        protected TestBusinessObject(SerializationContext context)
            : base(context)
        {{
        }
        public NestedObject InnerObject { get; set; }
    }
