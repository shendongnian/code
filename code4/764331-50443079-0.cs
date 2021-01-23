	public class ESDateTimeConverter : IsoDateTimeConverter
	{
		public ESDateTimeConverter()
		{
			base.DateTimeFormat = "yyyy-MM-ddTHH:mm:ss.fffZ";
		}
	}
