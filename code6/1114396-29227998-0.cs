    public class MyDataClass
    {
        public uint Value{ get; set;}
        public string Display{get;set;}
        public MyDataClass(string display, uint val)
        {
            Display = display;
            Value = val;
        }
        public override string ToString()
        {
             return this.Display;
        }
    }
