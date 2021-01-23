    internal abstract class MyBaseClass
    {
        public abstract void DoSomething();
        // This method can also be added later without having an effect on the derived classes
        public virtual void DoSomethingElse()
        {
            // Do something else...
        }
    }
    
    internal class MyDerivedClass : MyBaseClass
    {
        public override void DoSomething()
        {
            // Do something...
        }
    }
