    public class Class1 : ITest
    {
        public void Testing()
        {
            Console.WriteLine("Test");
        }
        public void Testing2()
        {
            Console.WriteLine("Test2");
        }
    }
    public interface ITest : ITest2
    {
        void Testing();
    }
    public interface ITest2
    {
        void Testing2();
    }
