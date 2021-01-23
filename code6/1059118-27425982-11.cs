    public static class XmlOperations
    {
        public static T GetData<T>(XElement data, eOperationType target) where T : IOperation
        {
            var clone = Activator.CreateInstance<T>();
    
            clone.ProcessXml(data);
    
            return clone;
        }
    }
