    [serializable]
    public class Container
    {
        private IEnumerable<object> data;
        public Container(IEnumerable data);
        public string[] GetFullyQualifiedReferences();        
    }
