    public abstract class MyAbClass
    { 
        public abstract void MyM1();
    }
    public interface IMyInterface 
    {
        void MyM2();
    }
    public class MyConcretClass1 : MyAbClass
    {
        public override void MyM1()
        {
            //Your implementation here
        }
    }
    public class MyConcretClass2 : IMyInterface
    {
        public void MyM2()
        {
            //Your implementation here
        }
    }
