    namespace WcfServiceLibrary3
    {
        public class Service1 : IService1
        {
            public Element GetElement(User type)
            {
                if (type == null) return null;
    
                return type.GetElement();
            }
        }
    }
