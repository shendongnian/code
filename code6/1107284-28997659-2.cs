    public class DataService : IDataService
	{
		public async Task<List<T>> GetDataAsync<T>(string url, IParser<T> parser)
		{
			// Do work
			return parser.ParseRawData("blah");
		}
	}
	public class ItemParser : IParser<Item>
	{
		public List<Item> ParseRawData(string rawData)
		{
			// Do work
		}
	}
	public class CommentParser : IParser<Comment>
	{
		public List<Comment> ParseRawData(string rawData)
		{
			// Do work
		}
	}
