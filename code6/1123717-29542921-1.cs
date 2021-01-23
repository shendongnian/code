    public class Class1
    {
        public FirstByte FirstByte { get; set; }
    }
    
    public class Class2
    {    
        public bool SomeMethod(Class1 class1)
        {
            uint test = 1;
    
            return class1.FirstByte >= (FirstByte) test;
        }
    }
