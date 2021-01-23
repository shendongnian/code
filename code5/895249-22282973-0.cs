    internal class MappingFields : ICloneable
    {
        public string Type { get; set; }
        public string Property1 { get; set; }
        public string Property2 { get; set; }
        public bool isFound { get; set; }
    
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    
    }
