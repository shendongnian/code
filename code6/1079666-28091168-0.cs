    class Order {
        public string Country { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<Product> Products { get; set; }
        private IPaymentProcessor paymentProcessor;
    
        public Order(IPaymentProcessor paymentProcessor) {
            this.paymentProcessor = paymentProcessor;
        }
    
        void MakePayment(Payment payment) {
            this.paymentProcessor.ProcessPayment(payment);
        }
    }
