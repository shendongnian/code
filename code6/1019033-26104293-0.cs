	public class FakeCache : ICache
	{
		public FakeCache(string regionName)
		{
			RegionName = regionName;
		}
		public object Get(object key)
		{
			return null;
		}
		public void Put(object key, object value)
		{
		}
		public void Remove(object key)
		{
		}
        ...
