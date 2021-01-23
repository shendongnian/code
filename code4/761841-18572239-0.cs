    public interface IF1Strategy
    {
       void f1();
    }
    public sealed class C : I1
    {
        private readonly IF1Strategy _f1Strategy;
 
        //strategy injected
        public C(IF1Strategy strategy)
        {
           _f1Strategy = strategy;
        }
        void f2()
        {
        }
        void f1()
        {
           //delegated to strategy
           _f1Strategy.f1();
        }
    }
