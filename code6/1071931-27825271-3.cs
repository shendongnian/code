    class Destination2: Decorator
    {
      public override void Operation()
      {
        base.Operation();
        AddedBehavior();
        Console.WriteLine("ConcreteDecoratorB.Operation()");
      }
     
      void AddedBehavior()
      {
      }
    
    }
