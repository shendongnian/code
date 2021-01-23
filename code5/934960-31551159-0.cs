    namespace System.Runtime.Serialization
    {
        [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
        public sealed class DataMemberAttribute : Attribute
        {
            string name;
            bool isNameSetExplicitly;
            int order = -1;
            bool isRequired;
            bool emitDefaultValue = false;
     
            public string Name
            {
                get { return name; }
                set { name = value; isNameSetExplicitly = true; }
            }
     
            public bool IsNameSetExplicitly
            {
                get { return isNameSetExplicitly; }
            }
     
            public int Order
            {
                get { return order; }
                set
                {
                    if (order < 0)
                        throw new InvalidDataContractException();
                    order = value;
                }
            }
     
            public bool IsRequired
            {
                get { return isRequired; }
                set { isRequired = value; }
            }
     
            public bool EmitDefaultValue
            {
                get { return emitDefaultValue; }
                set { emitDefaultValue = value; }
            }
        }
    }
