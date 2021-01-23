      public interface I1VariedBehavior
    {
        void f1(); // Varies for the implementation.
    }
    public abstract class I1SameBehavior
    {
        
        public void f2()
        {
            Console.WriteLine("f2 same behavior");
        }
    }
    public class F1Impl1 : I1VariedBehavior
    {
        public void f1() // f1 is own implementation 
        {
            Console.WriteLine("F1 own implementation 1");
        }
    }
    public class F1Impl2 : I1VariedBehavior
    {
        public void f1() // f1 is own implementation 
        {
            Console.WriteLine("F1 own implementation 2");
        }
    }
    public class C1 : I1SameBehavior
    {
        I1VariedBehavior strategy;
        public C1(I1VariedBehavior strategy)
        {
            this.strategy = strategy;
        }
        public void f1()
        {
            strategy.f1();
        }        
    }
    
    public class Client
    {
        public static void Main(String[] args)
        {
            C1 c1 = new C1(new F1Impl1());
            c1.f1();
            c1.f2();
            C1 c2 = new C1(new F1Impl2());
            c2.f1();
            c2.f2();
            Console.Read();
        }
    }
