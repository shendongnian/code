    public interface BaseInterface
    {
        string FirstName { get; set; }
        string LastName { get; set; }
    
        void Method1();
    }
    
    public interface ExtendedInterface
    {
        string FulllName { get; set; }
            
        void Method2();
    }
    
    public class ClassA : BaseInterface
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    
        public void Method1()
        { 
        }
    }
    
    public class ClassA : BaseInterface, ExtendedInterface
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    
        public string FullName { get; set; }
    
        public void Method1()
        {
        }
    
        public void Method2()
        {
        }
    }
