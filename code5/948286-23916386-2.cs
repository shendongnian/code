	[Route("/orders", "GET")]
	public class GetOrderHistoryRequest : IReturn<List<CustomerMonthlyOrders>>
	{
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
	}
