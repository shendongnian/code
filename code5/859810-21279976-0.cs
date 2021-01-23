    public class TypeData
    {
        public string Name { get; set; }
        public List<Data> Data { get; set; }
    }
    
    public struct Data
    {
        public double Value { get; set; }
        public bool IsValueActive { get; set; }
    
        public override string ToString()
        {
            return IsValueActive ? Value.ToString() : "0.0";
        }
    }
