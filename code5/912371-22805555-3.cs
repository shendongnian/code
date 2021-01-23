    interface IAdapter
    {
        void MethodA();
    }
    interface IAdaptee
    {
        void MethodB();
    }
    
    class Adapter<TAdaptee> : IAdapter where TAdaptee : IAdaptee, new()
    {
        private TAdaptee _adaptee;
        public Adapter()
        {
            _adaptee = new TAdaptee();
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
