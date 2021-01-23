    internal class EmailIndicatorA : IEmailIndicator
    {
        private readonly IServiceA serviceA;
        public EmailIndicatorA(IServiceA serviceA)
        {
            this.serviceA = serviceA;
        }
        
        (...)
    }
