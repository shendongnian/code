	[Route("/Table1","POST")]
	public class Table1 : IReturn<int>
	{
		[AutoIncrement]
		public int ID { get; set; } 
		public int Data1 { get; set; }
		public string Data2 { get; set; }
		public DateTime Timestamp { get; set; }
	}
    [Route("/Table1/Multi","POST")]
	public class Table1Multiple : IReturn<List<int>>
	{
		public List<Table1> Values { get; set; }
	}
