    public interface IPaymentProcessor<T> where T : IPaymentInfo
    {
        void ProcessPayment(T paymentInfo);
    }
    // Just one example
    public class CreditCardPaymentInfo : IPaymentInfo
    {
        public CardInfo CardInfo { get; set; }
    }
    public class CreditCardPaymentProcessor : IPaymentProcessor<CreditCardPaymentInfo>
    {
        public void ProcessPayment(CreditCardPaymentInfo paymentInfo)
        {
            // Do the card processing here - you have what you need
        }
    }
