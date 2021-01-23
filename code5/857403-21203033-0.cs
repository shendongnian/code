    abstract class A 
    {
       // forces subclasses to implement
       abstract void method1();
       
       virtual void method2() 
       {
          // some common logic
          // that sublcasses can
          // modify
       }
       protected void method3()
       {
          // some common logic
       }
    }
    class B : A 
    {
        void method1() 
        {
           // needs to be implemented
        }
        override void method2()
        {
           // optional: e.g. something added
           base.method1();
        }
    }
    class C : A    {
       //...
    }
