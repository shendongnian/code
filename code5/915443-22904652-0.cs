	public class ShopManager
	{
		[Inject]
		public IOrderNotification OrderNotification { get; set; }
		public ShopManager(string shopName)
		{
			//Do somethings
		}
		public int GetNotifyCount()
		{
			return OrderNotification.Count();
		}
	}
