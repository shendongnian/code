    public class Class1
    {
        public static FirstByte FirstByte { get; set; }
    }
    
    public class Class2
    {    
        public bool SomeMethod()
        {
            uint test = 1;
    
            return Class1.FirstByte >= (FirstByte) test;
        }
    }
