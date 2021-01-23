    public class SomeData
    {
        public string Time { get; set; }
        public double? Value { get; set; }
    
        public SomeData(string time, double? value)
        {
            this.time = time;   
            this.value = value;   
        }
    
        public SomeData() { }
    }
