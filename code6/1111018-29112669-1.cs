	public class ConsumerOfPay
	{
		private IPay _pay;
		public ConsumerOfPay(IPay pay)
		{
			_pay = new PayWrapper(pay);
		}
	}
