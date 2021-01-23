	public interface IData
	{
		void Set(string data);
	}
	public class StringObjectMapper
	{
		private readonly Dictionary<string, IData> mapping = new Dictionary<string, IData>();
		public void Set(string key, string value)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			
			mapping[key].Set(value);
		}
		internal void Add(string key, IData data)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			
			mapping.Add(key, data);
		}
	}
