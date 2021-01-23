    namespace ClassLibrary1
    {
        [ServiceContract]
        public interface IService1
        {
    
            [OperationContract]
            Element GetElement(CompositeType type);
    
        }
    
        [DataContract]
        public class Element
        {
            [DataMember]
            public string Name { get; internal set; }
        }
    
    
        [KnownType(typeof(CompositeTypeA))]
        [KnownType(typeof(CompositeTypeB))]
        [KnownType(typeof(CompositeTypeC))]
        public class CompositeType
        {
    
            public Element GetElement()
            {
                return new Element() { Name = TypeName };
            }
    
            protected virtual string TypeName
            {
                get { return "base"; }
            }
    
    
    
        }
    
        public class CompositeTypeA : CompositeType
        {
            protected override string TypeName
            {
                get { return "A"; }
            }
        }
    
        public class CompositeTypeB : CompositeType
        {
            protected override string TypeName
            {
                get { return "B"; }
            }
        }
    
        public class CompositeTypeC : CompositeType
        {
            protected override string TypeName
            {
                get { return "C"; }
            }
        }
    }
