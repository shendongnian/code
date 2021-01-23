    class Base
    {  
        public MyData { get; private set; }
        public Base(MyData data)
        {
           MyData = data;
        }
    }
    
    class Derived : Base
    { 
        public Derived(MyData data):base(data)
        {}
    
        // Methods that use MyData here...
    }
