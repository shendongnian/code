    class A
    {
       public B b{ get; private set; }
        
    
         public A()
        {
            b= new B();
        }
    
    
        public class B
        {
            public int number;
        }
    }
    A a = new A();
