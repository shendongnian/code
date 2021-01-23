    public class MyBaseClass
    {
        public virtual void RemoveItems()
        {
        }
    }
    public class MyDerivedClass : MyBaseClass 
    {
        public override void RemoveItems()
        {
           //your specific implementation for this child class
        }
    }
