    internal class EmailIndicatorAFactory : IEmailIndicatorFactory
    {
        private readonly IServiceA serviceA;
        public EmailIndicatorAFactory(IServiceA serviceA)
        {
            this.serviceA = serviceA;
        }
        public IEmailIndicator Create()
        {
            return new EmailIndicatorA(this.serviceA);
        }
    }
