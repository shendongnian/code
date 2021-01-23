    public class BaseClass
    {
        public string prop1 { get; set; }
        public string prop2 { get; set; }
        public string prop3 { get; set; } 
    
        public BaseClass(string p1 = "val1", string p2 = "val2", string p3 = "val3")
        {
            prop1 = p1,
            prop2 = p2,
            prop3 = p3
        }
    }
