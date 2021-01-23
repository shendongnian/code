    void Main()
    {
        Dummy d = new Dummy { Name = "A" };
        Action a = d.Method;
    
        d = new Dummy { Name = "B" };
        Action b = d.Method;
    
        d = null;
    
        a();
        b();
    }
    
    public class Dummy
    {
        public string Name { get; set; }
        public void Method()
        {
            Debug.WriteLine("Name=" + Name);
        }
    }
