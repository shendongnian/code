    public class Class1
    {
        public string Name { get; set; }
        public static explicit operator Class1(Class2 cls)
        {
            return new Class1 { Name = cls.Name };
        }
    }
    public class Class2
    {
        public string Name { get; set; }
        
        public static explicit operator Class2(Class1 cls)
        {
            return new Class2 { Name = cls.Name };
        }
    }
