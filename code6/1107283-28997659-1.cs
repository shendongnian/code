	public interface IDataService
	{
		Task<List<T>> GetDataAsync<T>(string url, IParser<T> parser);
	}
	public interface IParser<T>
	{
		List<T> ParseRawData(string rawData);
	}
