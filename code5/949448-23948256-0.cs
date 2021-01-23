    public abstract class MyBase
    {
        public abstract void MethodMustBeImplemented();
        public virtual void DoesNotHaveToBeOverwritten()
        {
          //Do WORk
        }
    }
    public class Implementor: MyBase
    {
    
    }
