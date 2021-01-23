     public abstract class TestBaseClass
    {
        public void test()
        {
            Console.WriteLine("base method");
        }
    }
    public class DerivedClass : TestBaseClass
    {
        public void testDerived()
        {
            Console.WriteLine("Derived method");
        }
    }
