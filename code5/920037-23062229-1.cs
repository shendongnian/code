	public class MyRepository : Repository
	{
		public MyRepository(string connectionString) : base(connectionString)
		{
		}
		public IEnumerable<MyMapObject> GetData()
		{
			return GetConnection(c => c.Query<MyMapObject>(query));
		}
		
		public IEnumerable<ResultObject> GetLotsOfData(Func<IEnumerable<MyMapObject>, IEnumerable<ResultObject>> process)
		{
			return GetConnection(c => c.Query<MyMapObject>(query, buffered: false), process);
		}
	}
