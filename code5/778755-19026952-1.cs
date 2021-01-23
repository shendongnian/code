    public class ProcessPaymentsFactory : IProcessPaymentsFactory
    {
        public ProcessPaymentsFactory(IProcessPayments paymentProcesser) { ... }
        public ProcessPayments Create(String accountNumber)
        {
            return new ProcessPayments(accountNumber, this.paymentProcesser);
        }
    }
