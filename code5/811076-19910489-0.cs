    Class A
    {
     public void Display()
     {
         Console.Writeline("I am from A");
     }
    }
    
    interface IA
    {
     void Display();
    }
    
    interface IB
    {
     void Display();
    }
    
    Class B : A, IA, IB
    {
      void AI.Display() { Console.Writeline("I am from AI.Display"); }
    }
    
    Class Final
    {
     static void Main()
     {
       B b = new B();
       b.Display(); // displays class A Display method.
       (b as IB).Display(); // displays class A Display method.
       (b as AI).Display(); // displays AI.Display
       Console.Readline();
     }
    }
