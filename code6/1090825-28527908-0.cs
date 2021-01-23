    interface INumberHandler
    {
        void Handle(int number);
    }
    class NumberViewModel : INumberHandler
    {
    }
    
    class NumberService
    {
        public void Calculate(INumberHandler handler)
        {
            handler.Handle(9);
        }
    }
