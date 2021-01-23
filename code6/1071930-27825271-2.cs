    class Destination1: Decorator
    {
      public override void Operation()
      {
        base.Operation();
        Console.WriteLine("ConcreteDecoratorA.Operation()");
      }
    
      void NewBehavior()
      {
        //this is a new behavior
      }
    }
