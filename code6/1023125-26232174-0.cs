    interface ISomeInterface
    {
        object Method(string xml);
    }
    
    class GenericClass<T> : ISomeInterface
    {
        void object ISomeInterface.Method(string xml)
        {
            return Method(xml);
        }
        public T Method(string xml)
        {
        }
    }
