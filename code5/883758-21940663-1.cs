	public class ExceptionTest : Exception
	{
		private Dictionary<string, string> InternalData { get; set; }
		public ExceptionTest(Dictionary<string, string> data)
		{
			InternalData = data;
		}
		
		public override Dictionary<string, string> Data 
		{
			get 
			{
				return InternalData;
			}
		}
	}
