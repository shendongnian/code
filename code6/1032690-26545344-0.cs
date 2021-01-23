    public class PaymentGatewayWrapper : LoggerBase
    {
        protected override Type LogPrefix
        {
            get { return this.GetType(); }
        }
    
        public void ProcessPayment(Object paymentInfo, Object customer,
        Guid orderGuid, ref Object processPaymentResult)
        {
            try
            {
                // TODO: Required operational level code
            }
            catch (System.Exception ex)
            {
                this.LogError("Error processing payment", ex);
            }
        }
    }
