    public interface
    {
        void MyMethod();
    }
    public class MyBaseClass : IMyInterface
    {
        public virtual void MyMethod()
        {
        }
    }
    public class MyInhertingClass : MyBaseClass
    {
        public override void MyMethod()
        {
        }
    }
