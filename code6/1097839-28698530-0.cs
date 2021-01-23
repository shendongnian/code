	public abstract class PaymentProcessor 
	{ 
		protected abstract void ThisMethodNeedsASpecializedService();
	}
	public class PaymentGateway1Processor : PaymentProcessor
	{
		private IPaymentGateway1Service paymentGateway1Service;
		public PaymentGateway1Processor(IPaymentGateway1Service paymentGateway1Service){
			this.paymentGateway1Service = paymentGateway1Service;
		}
		public void ThisMethodNeedsASpecializedService()
		{
			this.paymentGateway1Service.ProcessPayment(); 
		}
	}
