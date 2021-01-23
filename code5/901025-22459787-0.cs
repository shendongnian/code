    class A
    {
       void MethodOne()
       {
          //Here you perform your obligatory logic.
          //Then, call the overridable logic.
          MethodOneCore();
       }
    
       virtual void MethodOneCore()
       {
          //Here you perform overridable logic.
       }
    }
    
    class B: A
    {
       override void MethodOneCore()
       {
          //Here you override the "core" logic, while keeping the obligatory logic intact.
       }
    }
