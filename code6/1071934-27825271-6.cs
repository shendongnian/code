    abstract class Decorator : AbstractDestination
    {
      protected AbstractDestination abstractDestination;
     
      public void SetDestination(AbstractDestination abstractDestination)
      {
        this.abstractDestination= abstractDestination;
      }
     
      public override void Operation()
      {
         if (abstractDestination != null)
         {
           abstractDestination.Operation();
         }
      }
    }
