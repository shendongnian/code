    // 
    [Route("/Table1/Multi","POST")]
	public class Table1Multiple : List<Table1>, IReturn<List<int>>
	{
	}
