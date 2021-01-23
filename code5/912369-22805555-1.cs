    public interface IAdapter
    {
        void MethodA();
    }
    public interface IAdaptee
    {
        void MethodB();
    }
    
    class Adapter<TAdaptee> : IAdapter where TAdaptee : IAdaptee, new()
    {
        private TAdaptee _adaptee;
        Adapter(TAdaptee adaptee)
        {
            _adaptee = adaptee;
        }
 
        public void MethodA()
        {
            _adaptee.MethodB();
        }
    }
    class AdapteeA : IAdaptee
    {
        public void MethodB()
        {
            Console.WriteLine("AdapteeA");
        }
    }
    class AdapteeB : IAdaptee
    {
        public void MethodB()
        {
            Console.WriteLine("AdapteeB");
        }
    }
