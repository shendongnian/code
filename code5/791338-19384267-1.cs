    public class Service1 : IService1
    {
        public Element GetElement(CompositeType type)
        {
            if (type == null) return null;
    
            return type.GetElement();
        }
    }
