   	public class GridModel
	{
		public int ID { get; set; }
		public string SHORT_NAME { get; set; }
		public string CARRIER_NAME { get; set; }
		public List<SellDuration> SellDuration { get; set; }
	}
	public class SellDuration
	{
		public DateTime YMDH { get; set; }
		public double SELL_DURATION { get; set; }
	}
