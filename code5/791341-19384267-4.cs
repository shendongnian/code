    namespace ClassLibrary1
    {
        [ServiceContract]
        public interface IService1
        {
    
            [OperationContract]
            Element GetElement(User type);
    
        }
    
        [DataContract]
        public class Element
        {
            [DataMember]
            public string Name { get; internal set; }
        }
    
    
        [KnownType(typeof(UserA))]
        [KnownType(typeof(UserB))]
        [KnownType(typeof(UserC))]
        public class User
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
    
        public class UserA : User
        {
            protected override string TypeName
            {
                get { return "A"; }
            }
        }
    
        public class UserB : User
        {
            protected override string TypeName
            {
                get { return "B"; }
            }
        }
    
        public class UserC : User
        {
            protected override string TypeName
            {
                get { return "C"; }
            }
        }
    }
